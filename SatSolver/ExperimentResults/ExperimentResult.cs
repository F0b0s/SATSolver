using System.Collections.Generic;

namespace SatSolver.ExperimentResults
{
    public class ExperimentResult
    {
        public ExperimentResult()
        {
            PercentageSatisfiability = new List<float>();
        }

        public int VariableCount { get; set; }
        public int KonyncCount { get; set; }
        public int FreeMembers { get; set; }
        public int ExperimentRepeat { get; set; }
        public float TeoreticSatisfiability { get; set; }
        public List<float> PercentageSatisfiability { get; private set; }
    }
}
