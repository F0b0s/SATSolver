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
            backgroundWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCompleted;
            backgroundWorker.ProgressChanged += BackgroundWorkerProgressChanged;

            if (tabControl1.SelectedIndex == 0)
            {
                backgroundWorker.DoWork += BackgroundWorkerDoWork;

                variableCount = (int)numMembersCount.Value;
                iKonyncCount = (int)numKonyncCount.Value;
                iFreeMembers = (int)numFreeMembers.Value;
                iExperimentRepeat = (int)numExperimentCount.Value;
                bIsAlternative = checkBox1.Checked;
            }
            else
            {
                backgroundWorker.DoWork += BackgroundWorkerDoWorkBorderSatisfiability;

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

        void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
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
                
                int[] freeMembersIndex = BinaryCounter.BinaryCounter.FindFreeMembersIndex(countParams, countFreeMembers);
                uint mask = BinaryCounter.BinaryCounter.GetMask(freeMembersIndex);
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

        void BackgroundWorkerDoWorkBorderSatisfiability(object sender, DoWorkEventArgs e)
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
                Log.Debug("------------------Next generation");
                int num = iKonyncCount;
                int countParams = variableCount;
                int countFreeMembers = iFreeMembers;
                uint countUniqueConjunction = 0;

                var buffer = new byte[BinaryCounter.BinaryCounter.FindSizeBitMapForCountParams(countParams)];
                Log.DebugFormat("Size of mass = {0}", buffer.Length);

                int[] freeMembersIndex = BinaryCounter.BinaryCounter.FindFreeMembersIndex(countParams, countFreeMembers);
                uint mask = BinaryCounter.BinaryCounter.GetMask(freeMembersIndex);
                uint rotatedMask = BinaryCounter.BinaryCounter.GetRotateMask(mask);
                Log.DebugFormat("Mask = {0}", mask);
                Log.DebugFormat("RotateMask = {0}", rotatedMask);

                float currentSatisfiability = 0;
                int indexMinterm = 0;
                do
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
                    currentSatisfiability = Convert.ToSingle(countUniqueConjunction) / (1 << variableCount);
                    indexMinterm++;

                    Log.Debug("Total = " + currentSatisfiability);

                } while((currentSatisfiability < borderSatisfiability) && (!e.Cancel));

                borderExperimentResult.PercentageSatisfiability.Add(currentSatisfiability);
                borderExperimentResult.BorderCount.Add(indexMinterm);

                backgroundWorker.ReportProgress(experimentIndex);

                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
            e.Result = borderExperimentResult;
        }

        void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    var experimentResult = (ExperimentResult)e.Result;
                    var reportForm = new ReportForm(experimentResult);
                    reportForm.Show();
                }
                else
                {
                    var borderExperimentResult = (BorderExperimentResult)e.Result;
                    var reportBorderForm = new ReportBorderForm(borderExperimentResult);
                    reportBorderForm.Show();
                }
            }
        }


        private void DisableControls()
        {
            foreach (Control item in Controls)
            {
                item.Enabled = false;
            }
            progressBar1.Enabled = true;
            lbCalculateProcess.Enabled = true;
        }

        private void EnableControls()
        {
            foreach (Control item in Controls)
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
