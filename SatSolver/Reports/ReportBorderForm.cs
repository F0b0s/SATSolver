using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SatSolver.ExperimentResults;
using ZedGraph;

namespace SatSolver.Reports
{
    public partial class ReportBorderForm : Form
    {
        public ReportBorderForm(BorderExperimentResult borderExperimentResult)
        {
            InitializeComponent();

            lbVariableCount.Text = borderExperimentResult.VariableCount.ToString();
            lbFreeMembers.Text = borderExperimentResult.FreeMembers.ToString();
            lbExperimentRepeat.Text = borderExperimentResult.ExperimentRepeat.ToString();

            float meanKonync = borderExperimentResult.BorderCount.Sum() / borderExperimentResult.BorderCount.Count;
            lbKonyncCount.Text = meanKonync.ToString();

            GraphPane graphPane = this.zedGraphControl1.GraphPane;
            graphPane.CurveList.Clear();
            graphPane.Title.Text = "Demonstration of experiment by calculation of realizability of function";
            graphPane.XAxis.Title.Text = "Experiment Number";
            graphPane.YAxis.Title.Text = "Probability";
            string[] massX = new string[borderExperimentResult.PercentageSatisfiability.Count];

            for (int i = 0; i < borderExperimentResult.PercentageSatisfiability.Count; i++)
            {
                massX[i] = borderExperimentResult.PercentageSatisfiability[i].ToString();
            }


            PointPairList points = new PointPairList();
            PointPairList list3 = new PointPairList();
            Random random = new Random();
            for (int i = 0; i < borderExperimentResult.BorderCount.Count; i++)
            {
                double x = i + 1.0;
                double z = 5.0;
                points.Add(x, (double)borderExperimentResult.BorderCount[i], z);
            }
            BarItem item = graphPane.AddBar("Count Minterms", points, Color.Blue);
            graphPane.BarSettings.MinBarGap = 0f;
            graphPane.XAxis.Scale.TextLabels = massX;
            graphPane.XAxis.Type = AxisType.Text;

            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Invalidate();
        }
    }
}
