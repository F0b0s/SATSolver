using System.Collections.Generic;

namespace SatSolver.ExperimentResults
{
    public class BorderExperimentResult
    {
        public BorderExperimentResult()
        {
            PercentageSatisfiability = new List<float>();
            BorderCount = new List<int>();
        }

        public List<int> BorderCount { get; private set; }
        public int VariableCount { get; set; }
        public int FreeMembers { get; set; }
        public int ExperimentRepeat { get; set; }
        public List<float> PercentageSatisfiability { get; private set; }
    }
}
