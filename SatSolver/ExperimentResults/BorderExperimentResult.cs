using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatSolver
{
    public class BorderExperimentResult
    {
        private int _iVariableCount;
        private int _iFreeMembers;
        private int _iExperimentRepeat;
        private List<float> _lstPercentageSatisfiability;
        private List<int> _lstBorder;

        public BorderExperimentResult()
        {
            _lstPercentageSatisfiability = new List<float>();
            _lstBorder = new List<int>();
        }

        public List<int> BorderCount
        {
            get { return _lstBorder; }
        }

        public int VariableCount
        {
            get { return _iVariableCount; }
            set { _iVariableCount = value; }
        }

        public int FreeMembers
        {
            get { return _iFreeMembers; }
            set { _iFreeMembers = value; }
        }

        public int ExperimentRepeat
        {
            get { return _iExperimentRepeat; }
            set { _iExperimentRepeat = value; }
        }

        public List<float> PercentageSatisfiability
        {
            get { return _lstPercentageSatisfiability; }
        }
    }
}
