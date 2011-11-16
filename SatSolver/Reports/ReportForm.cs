using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SatSolver.ExperimentResults;
using ZedGraph;

namespace SatSolver.Reports
{
    public partial class ReportForm : Form
    {
        public ReportForm(ExperimentResult experimentResult)
        {
            InitializeComponent();

            lbVariableCount.Text = experimentResult.VariableCount.ToString();
            lbKonyncCount.Text = experimentResult.KonyncCount.ToString();
            lbFreeMembers.Text = experimentResult.FreeMembers.ToString();
            lbExperimentRepeat.Text = experimentResult.ExperimentRepeat.ToString();
            lbTeoreticSatisfiability.Text = experimentResult.TeoreticSatisfiability.ToString();

            float meanPracticSatisf = experimentResult.PercentageSatisfiability.Sum() / experimentResult.PercentageSatisfiability.Count;
            lbPracticSatisfiability.Text = meanPracticSatisf.ToString();

            lbRelation.Text = ((Math.Abs(meanPracticSatisf - experimentResult.TeoreticSatisfiability) * 100) / meanPracticSatisf).ToString();

            GraphPane graphPane = this.zedGraphControl1.GraphPane;
            graphPane.CurveList.Clear();
            graphPane.Title.Text = "Demonstration of experiment by calculation of realizability of function";
            graphPane.XAxis.Title.Text = "Experiment Number";
            graphPane.YAxis.Title.Text = "Probability";
            PointPairList points = new PointPairList();
            PointPairList list3 = new PointPairList();
            Random random = new Random();
            for (int i = 0; i < experimentResult.ExperimentRepeat; i++)
            {
                double x = i + 1.0;
                double z = 5.0;
                points.Add(x, (double)experimentResult.TeoreticSatisfiability, z);
                list3.Add(x, (double)experimentResult.PercentageSatisfiability[i], z);
            }
            BarItem item = graphPane.AddBar("Teoretic value", points, Color.Blue);
            BarItem item2 = graphPane.AddBar("Practic value", list3, Color.Red);
            graphPane.BarSettings.MinBarGap = 0f;
            graphPane.XAxis.Scale.Max = experimentResult.ExperimentRepeat + 1;
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Invalidate();

        }
    }
}
