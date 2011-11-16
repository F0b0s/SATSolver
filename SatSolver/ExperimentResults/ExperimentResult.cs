using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatSolver
{
    public class ExperimentResult
    {
        private int _iVariableCount;
        private int _iKonyncCount;
        private int _iFreeMembers;
        private int _iExperimentRepeat;
        private List<float> _lstPercentageSatisfiability;
        private float _fTeoreticSatisfiability;

        public ExperimentResult()
        {
            _lstPercentageSatisfiability = new List<float>();
        }

        public int VariableCount
        {
            get { return _iVariableCount; }
            set { _iVariableCount = value; }
        }

        public int KonyncCount
        {
            get { return _iKonyncCount; }
            set { _iKonyncCount = value; }
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

        public float TeoreticSatisfiability
        {
            get { return _fTeoreticSatisfiability; }
            set { _fTeoreticSatisfiability = value; }

        }

        public List<float> PercentageSatisfiability
        {
            get { return _lstPercentageSatisfiability; }
        }
    }
}
