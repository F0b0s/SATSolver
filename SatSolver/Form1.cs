using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SatSolver.ExperimentResults;
using SatSolver.Reports;

namespace SatSolver
{
    public partial class Form1 : Form
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        BackgroundWorker backgroundWorker;

        private int variableCount;
        private int iKonyncCount;
        private int iFreeMembers;
        private int iExperimentRepeat;
        private bool bIsAlternative;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(_backgroundWorker_ProgressChanged);

            if (tabControl1.SelectedIndex == 0)
            {
                backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);

                variableCount = (int)numMembersCount.Value;
                iKonyncCount = (int)numKonyncCount.Value;
                iFreeMembers = (int)numFreeMembers.Value;
                iExperimentRepeat = (int)numExperimentCount.Value;
                bIsAlternative = checkBox1.Checked;
            }
            else
            {
                backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork_BorderSatisfiability);

                variableCount = (int)numBorderVariableCount.Value;
                iFreeMembers = (int)numFreeMembers.Value;
                iExperimentRepeat = (int)numBorderRepeatCount.Value;
            }
            progressBar1.Minimum = 0;
            progressBar1.Maximum = iExperimentRepeat;
            progressBar1.Value = 0;
            backgroundWorker.RunWorkerAsync();

            DisableControls();
            btnStopCalculate.Enabled = true;
        }

        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var experimentResult = new ExperimentResult
                                       {
                                           VariableCount = variableCount,
                                           KonyncCount = iKonyncCount,
                                           FreeMembers = iFreeMembers,
                                           ExperimentRepeat = iExperimentRepeat
                                       };

            if (bIsAlternative)
            {
                experimentResult.TeoreticSatisfiability = TeoreticFunctions.TeoreticFunctions.TeoreticProbabilityWithLogariphm(variableCount, iKonyncCount, iFreeMembers);                
            }
            else
            {
                experimentResult.TeoreticSatisfiability = TeoreticFunctions.TeoreticFunctions.FindTeoreticProbabilityWithRepeatAlternative(variableCount, iKonyncCount,
                    iFreeMembers);
            }

            Log.Debug("-------------------------New checking at " + DateTime.Now);
            Log.Debug("Count minterms - " + iKonyncCount);
            Log.Debug("Count free members - " + iFreeMembers);
            Log.Debug("Count parameters - " + variableCount);

            for (int experimentIndex = 0; experimentIndex < iExperimentRepeat; experimentIndex++)
            {
                Log.Debug("------------------Next generation");
                int num = iKonyncCount;
                int countParams = variableCount;
                int countFreeMembers = iFreeMembers;
                uint countUniqueConjunction = 0;
                
                var buffer = new byte[BinaryCounter.BinaryCounter.FindSizeBitMapForCountParams(countParams)];
                Log.DebugFormat("Size of mass = {0}", buffer.Length);
                
                int[] source = BinaryCounter.BinaryCounter.FindFreeMembersIndex(countParams, countFreeMembers);
                uint mask = BinaryCounter.BinaryCounter.GetMask(source);
                uint rotatedMask = BinaryCounter.BinaryCounter.GetRotateMask(mask);
                Log.DebugFormat("Mask = {0}", mask);
                Log.DebugFormat("RotateMask = {0}", rotatedMask);

                for (int i = 0; (i < num) && (!e.Cancel); i++)
                {
                    uint generatedConjunction = BinaryCounter.BinaryCounter.GetRandomСonjunction(countParams);
                    Log.DebugFormat("Generate Digit = {0}", generatedConjunction);

                    foreach (var recoveredConjunction in BinaryCounter.BinaryCounter.RecoveredConjunction(mask, rotatedMask, generatedConjunction, countFreeMembers))
                    {
                        uint byteIndex = recoveredConjunction / 8;
                        Log.Debug("                PereborDigit = " + recoveredConjunction);
                        Log.Debug("                Index = " + byteIndex);
                        byte conjunctionByte = BinaryCounter.BinaryCounter.GetCheckedBitrForConjunction(recoveredConjunction);
                        if ((buffer[byteIndex] & conjunctionByte) == 0)
                            countUniqueConjunction++;

                        Log.Debug("                Count = " + countUniqueConjunction);
                        buffer[byteIndex] |= conjunctionByte;
                    }
                }

                float num18 = Convert.ToSingle(countUniqueConjunction) / (1 << variableCount);
                Log.Debug("Total = " + num18);

                // записываем результаты и отображаемся
                experimentResult.PercentageSatisfiability.Add(num18);
                backgroundWorker.ReportProgress(experimentIndex);

                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }


            }
            e.Result = experimentResult;
        }

        void backgroundWorker_DoWork_BorderSatisfiability(object sender, DoWorkEventArgs e)
        {
            var borderExperimentResult = new BorderExperimentResult();
            borderExperimentResult.VariableCount = variableCount;
            borderExperimentResult.FreeMembers = iFreeMembers;
            borderExperimentResult.ExperimentRepeat = iExperimentRepeat;

            float borderSatisfiability = (float)numBorderSatisfiability.Value;
            var rnd = new Random();

            Log.Debug("-------------------------New checking at " + DateTime.Now);
            Log.Debug("Count minterms - " + iKonyncCount);
            Log.Debug("Count free members - " + iFreeMembers);
            Log.Debug("Count parameters - " + variableCount);

            for (int experimentIndex = 0; (experimentIndex < iExperimentRepeat) && (!e.Cancel); experimentIndex++)
            {
                int num11;
                Log.Debug("------------------Next generation");
                //int num = _iKonyncCount;
                int iVariableCount = this.variableCount;
                int num3 = iFreeMembers;
                uint num4 = 0;
                int num6 = -1;
                int num7 = -1;
                int[] source = new int[num3];
                int num8 = ((1) << iVariableCount) / 8;
                if (num8 == 0)
                {
                    num8++;
                }
                byte[] buffer = new byte[num8];
                Log.Debug("Size of mass = " + num8);
                int index = 0;
                while (index < num3)
                {
                    int num10 = rnd.Next() % iVariableCount;
                    if (!source.Contains<int>(num10))
                    {
                        source[index] = num10;
                        index++;
                    }
                }
                for (num11 = 0; num11 < num3; num11++)
                {
                    int num12 = 0;
                    num12 = ((int)1) << source[num11];
                    num6 ^= num12;
                }
                num7 ^= num6;
                Log.Debug("Mask = " + num6);
                Log.Debug("RotateMask = " + num7);

                float currentSatisfiability = 0;
                int indexMinterm = 0;
                do
                {
                    int num5 = rnd.Next() % (1 << iVariableCount);
                    Log.Debug("Generate Digit = " + num5);
                    int num13 = 0;
                    for (int i = 0; i < (1 << num3); i++)
                    {
                        num13 |= num6;
                        num13++;
                        num13 &= num7;
                        int num14 = num5 ^ num13;
                        int num16 = num14 / 8;
                        Log.Debug("                PereborDigit = " + num14);
                        Log.Debug("                Index = " + num16);
                        byte num17 = Convert.ToByte((int)(((int)1) << (num14 % 8)));
                        if ((buffer[num16] & num17) == 0)
                        {
                            num4++;
                        }
                        Log.Debug("                Count = " + num4);
                        buffer[num16] = (byte)(buffer[num16] | Convert.ToByte((int)(((int)1) << (num14 % 8))));
                    }
                    currentSatisfiability = Convert.ToSingle(num4) / ((float)((1) << this.variableCount));
                    indexMinterm++;

                    Log.Debug("Total = " + currentSatisfiability);

                } while((currentSatisfiability < borderSatisfiability) && (!e.Cancel));

                borderExperimentResult.PercentageSatisfiability.Add(currentSatisfiability);
                borderExperimentResult.BorderCount.Add(indexMinterm);

                backgroundWorker.ReportProgress(experimentIndex);

                if (backgroundWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
            }
            e.Result = borderExperimentResult;
        }

        void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = (int)e.ProgressPercentage;
        }

        void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableControls();
            btnStopCalculate.Enabled = false;
            progressBar1.Value = 0;

            if (e.Error != null)
            {
                MessageBox.Show("Внимание", "Расчет был прерван в результате ошибки: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {

            }
            else
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    ExperimentResult experimentResult = (ExperimentResult)e.Result;
                    ReportForm reportForm = new ReportForm(experimentResult);
                    reportForm.Show();
                }
                else
                {
                    BorderExperimentResult borderExperimentResult = (BorderExperimentResult)e.Result;
                    ReportBorderForm reportBorderForm = new ReportBorderForm(borderExperimentResult);
                    reportBorderForm.Show();
                }
            }
        }


        private void DisableControls()
        {
            foreach (Control item in this.Controls)
            {
                item.Enabled = false;
            }
            progressBar1.Enabled = true;
            lbCalculateProcess.Enabled = true;
        }

        private void EnableControls()
        {
            foreach (Control item in this.Controls)
            {
                item.Enabled = true;
            }
            progressBar1.Enabled = false;
            lbCalculateProcess.Enabled = false;
        }

        private void btnStopCalculate_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            btnStopCalculate.Enabled = false;
        }
    }
}
