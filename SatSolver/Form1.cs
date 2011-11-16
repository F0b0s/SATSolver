using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SatSolver.TeoreticFunctions;
using SatSolver.Reports;

namespace SatSolver
{
    public partial class Form1 : Form
    {
        BackgroundWorker _backgroundWorker;

        private int _iVariableCount;
        private int _iKonyncCount;
        private int _iFreeMembers;
        private int _iExperimentRepeat;
        private bool _bIsAlternative;
        private bool _bIsStop;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker_RunWorkerCompleted);
            _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(_backgroundWorker_ProgressChanged);

            if (tabControl1.SelectedIndex == 0)
            {
                _backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);

                _iVariableCount = (int)numMembersCount.Value;
                _iKonyncCount = (int)numKonyncCount.Value;
                _iFreeMembers = (int)numFreeMembers.Value;
                _iExperimentRepeat = (int)numExperimentCount.Value;
                _bIsAlternative = checkBox1.Checked;
            }
            else
            {
                _backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork_BorderSatisfiability);

                _iVariableCount = (int)numBorderVariableCount.Value;
                _iFreeMembers = (int)numFreeMembers.Value;
                _iExperimentRepeat = (int)numBorderRepeatCount.Value;
            }
            progressBar1.Minimum = 0;
            progressBar1.Maximum = _iExperimentRepeat;
            progressBar1.Value = 0;
            _backgroundWorker.RunWorkerAsync();

            DisableControls();
            btnStopCalculate.Enabled = true;
        }

        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ExperimentResult experimentResult = new ExperimentResult();
            experimentResult.VariableCount = _iVariableCount;
            experimentResult.KonyncCount = _iKonyncCount;
            experimentResult.FreeMembers = _iFreeMembers;
            experimentResult.ExperimentRepeat = _iExperimentRepeat;
            Random rnd = new Random();

            if (_bIsAlternative)
            {
                experimentResult.TeoreticSatisfiability = TeoreticFunctions.TeoreticFunctions.TeoreticProbabilityWithLogariphm(_iVariableCount, _iKonyncCount, _iFreeMembers);                
            }
            else
            {
                experimentResult.TeoreticSatisfiability = TeoreticFunctions.TeoreticFunctions.FindTeoreticProbabilityWithRepeatAlternative(_iVariableCount, _iKonyncCount,
                    _iFreeMembers);
            }

            using (StreamWriter sw = new StreamWriter(File.Open("Log.txt", FileMode.Append)))
            {
                sw.WriteLine("-------------------------New checking at " + DateTime.Now);
                sw.WriteLine("Count minterms - " + _iKonyncCount);
                sw.WriteLine("Count free members - " + _iFreeMembers);
                sw.WriteLine("Count parameters - " + _iVariableCount);

                for (int experimentIndex = 0; experimentIndex < _iExperimentRepeat; experimentIndex++)
                {
                    int num11;
                    sw.WriteLine("------------------Next generation");
                    int num = _iKonyncCount;
                    int num2 = _iVariableCount;
                    int num3 = _iFreeMembers;
                    uint num4 = 0;
                    int num6 = -1;
                    int num7 = -1;
                    int[] source = new int[num3];
                    int num8 = ((1) << num2) / 8;
                    if (num8 == 0)
                    {
                        num8++;
                    }
                    byte[] buffer = new byte[num8];
                    sw.WriteLine("Size of mass = " + num8);
                    DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                    int index = 0;
                    while (index < num3)
                    {
                        int num10 = rnd.Next() % num2;
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
                    sw.WriteLine("Mask = " + num6);
                    sw.WriteLine("RotateMask = " + num7);
                    for (num11 = 0; (num11 < num) && (!e.Cancel); num11++)
                    {
                        int num5 = rnd.Next() % (((int)1) << num2);
                        sw.WriteLine("Generate Digit = " + num5);
                        int num13 = 0;
                        for (int i = 0; i < (((int)1) << num3); i++)
                        {
                            num13 |= num6;
                            num13++;
                            num13 &= num7;
                            int num14 = num5 ^ num13;
                            int num16 = num14 / 8;
                            sw.WriteLine("                PereborDigit = " + num14);
                            sw.WriteLine("                Index = " + num16);
                            byte num17 = Convert.ToByte((int)(((int)1) << (num14 % 8)));
                            if ((buffer[num16] & num17) == 0)
                            {
                                num4++;
                            }
                            sw.WriteLine("                Count = " + num4);
                            buffer[num16] = (byte)(buffer[num16] | Convert.ToByte((int)(((int)1) << (num14 % 8))));
                        }
                    }
                    float num18 = Convert.ToSingle(num4) / ((float)((1) << _iVariableCount));
                    sw.WriteLine("Total = " + num18);

                    // записываем результаты и отображаемся
                    experimentResult.PercentageSatisfiability.Add(num18);
                    _backgroundWorker.ReportProgress(experimentIndex);

                    if (_backgroundWorker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                }
            }
            e.Result = experimentResult;
        }

        void backgroundWorker_DoWork_BorderSatisfiability(object sender, DoWorkEventArgs e)
        {
            BorderExperimentResult borderExperimentResult = new BorderExperimentResult();
            borderExperimentResult.VariableCount = _iVariableCount;
            borderExperimentResult.FreeMembers = _iFreeMembers;
            borderExperimentResult.ExperimentRepeat = _iExperimentRepeat;

            float borderSatisfiability = (float)numBorderSatisfiability.Value;
            Random rnd = new Random();

            using (StreamWriter sw = new StreamWriter(File.Open("Log.txt", FileMode.Append)))
            {
                sw.WriteLine("-------------------------New checking at " + DateTime.Now);
                sw.WriteLine("Count minterms - " + _iKonyncCount);
                sw.WriteLine("Count free members - " + _iFreeMembers);
                sw.WriteLine("Count parameters - " + _iVariableCount);

                for (int experimentIndex = 0; (experimentIndex < _iExperimentRepeat) && (!e.Cancel); experimentIndex++)
                {
                    int num11;
                    sw.WriteLine("------------------Next generation");
                    //int num = _iKonyncCount;
                    int iVariableCount = _iVariableCount;
                    int num3 = _iFreeMembers;
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
                    sw.WriteLine("Size of mass = " + num8);
                    DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
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
                    sw.WriteLine("Mask = " + num6);
                    sw.WriteLine("RotateMask = " + num7);

                    float currentSatisfiability = 0;
                    int indexMinterm = 0;
                    do
                    {
                        int num5 = rnd.Next() % (1 << iVariableCount);
                        sw.WriteLine("Generate Digit = " + num5);
                        int num13 = 0;
                        for (int i = 0; i < (1 << num3); i++)
                        {
                            num13 |= num6;
                            num13++;
                            num13 &= num7;
                            int num14 = num5 ^ num13;
                            int num16 = num14 / 8;
                            sw.WriteLine("                PereborDigit = " + num14);
                            sw.WriteLine("                Index = " + num16);
                            byte num17 = Convert.ToByte((int)(((int)1) << (num14 % 8)));
                            if ((buffer[num16] & num17) == 0)
                            {
                                num4++;
                            }
                            sw.WriteLine("                Count = " + num4);
                            buffer[num16] = (byte)(buffer[num16] | Convert.ToByte((int)(((int)1) << (num14 % 8))));
                        }
                        currentSatisfiability = Convert.ToSingle(num4) / ((float)((1) << _iVariableCount));
                        indexMinterm++;                       
                        
                        sw.WriteLine("Total = " + currentSatisfiability);

                    } while((currentSatisfiability < borderSatisfiability) && (!e.Cancel));

                    borderExperimentResult.PercentageSatisfiability.Add(currentSatisfiability);
                    borderExperimentResult.BorderCount.Add(indexMinterm);

                    _backgroundWorker.ReportProgress(experimentIndex);

                    if (_backgroundWorker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
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
            _backgroundWorker.CancelAsync();
            btnStopCalculate.Enabled = false;
        }
    }
}
