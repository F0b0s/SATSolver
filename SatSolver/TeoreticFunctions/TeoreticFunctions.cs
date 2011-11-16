using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatSolver.TeoreticFunctions
{
    class TeoreticFunctions
    {
        public static float FindTeoreticProbability(uint n, uint m, uint r)
        {
            float num = 0f;
            for (int i = 1; i <= m; i++)
            {
                num = (num + Convert.ToSingle((Math.Pow(2.0, (double)r) / Math.Pow(2.0, (double)n)))) - ((num * Convert.ToSingle((Math.Pow(2.0, (double)r) / Math.Pow(2.0, (double)n)))) * (Convert.ToSingle(r) / ((float)(n - 1))));
            }
            return num;
        }

        public static float FindTeoreticProbabilityWithRepeat(int n, int m, int r)
        {
            float num = 0f;
            for (int i = 1; i <= m; i++)
            {
                num = (num + Convert.ToSingle((Math.Pow(2.0, (double)r) / Math.Pow(2.0, (double)n)))) - (((num * Convert.ToSingle((Math.Pow(2.0, (double)r) / Math.Pow(2.0, (double)n)))) * (Convert.ToSingle(r) / ((float)(n - 1)))) * (1f - Convert.ToSingle(Math.Pow(2.7182818284590451, ((double)-Convert.ToSingle((int)(m - 1))) / Math.Pow(2.0, (double)n)))));
            }
            return num;
        }

        public static float FindTeoreticProbabilityWithRepeatAlternative(int n, int m, int r)
        {
            return Convert.ToSingle((double)(((m * Math.Pow(2.0, (double)r)) * (1.0 - ((m * Math.Pow(2.0, (double)r)) / (4.16 * Math.Pow(2.0, (double)n))))) / Math.Pow(2.0, (double)n)));
        }

        public static float TeoreticProbabilityWithLogariphm(int n, int m, int r)
        {
            float num = 0f;
            for (int i = 0; i <= m; i++)
            {
                float chislitel = Convert.ToSingle(num + Math.Pow(2, r) / Math.Pow(2, n) - num * (Math.Pow(2, r) / Math.Pow(2, n)) * ((double)r / n));
                float temp = (float)Math.Log(n);
                float znamen = Convert.ToSingle((n * temp) / (1 - (1 / temp - 0.1)));
                num = chislitel / znamen;
            }
            return num;
        }

        public static float TeoreticProbabilityMathModel(int n, int m, int r)
        {
            float num = 0f;
            for (int i = 0; i <= m; i++)
            {
                float chislitel = Convert.ToSingle(num + Math.Pow(2, r) / Math.Pow(2, n) - num * (Math.Pow(2, r) / Math.Pow(2, n)) * ((double)r / n + r));
                float znamen = Convert.ToSingle(0.8 * (n - r));
                num = chislitel / znamen;
            }
            return num;
        }
    }
}
