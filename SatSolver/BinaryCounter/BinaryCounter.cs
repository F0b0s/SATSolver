using System;
using System.Collections.Generic;

namespace SatSolver.BinaryCounter
{
    public class BinaryCounter
    {
        private static readonly Random Random = new Random(Environment.TickCount);

        public static int[] FindFreeMembersIndex(int countMembers, int countFreeMembers)
        {
            if (countFreeMembers >= countMembers)
                throw new ArgumentException("Количество свободных членов равно|больше общему количеству членов");

            var freeIndex = new List<int>();

            while (freeIndex.Count < countFreeMembers)
            {
                var index = Random.Next(countMembers - 1);

                if (!freeIndex.Contains(index))
                    freeIndex.Add(index);
            }
            return freeIndex.ToArray();
        }

        public static IEnumerable<int> RecoveredConjunction(int mask, int rotateMask, int conjunction, int countFreeMembers)
        {
            int currentConjunction = 0;
            for (int i = 0; i < 1 << countFreeMembers; i++)
            {
                currentConjunction |= mask; // TODO: разобраться надо ли обнулять здесь
                currentConjunction++;
                currentConjunction &= rotateMask;
                int generatedConjunction = conjunction ^ currentConjunction;
                yield return generatedConjunction;
            }
        }

        public static int FindSizeBitMapForCountParams(int countParams)
        {
            var result = (int) Math.Pow(2, countParams) / 8;
            return  result == 0 ? 1 : result;
        }

        /// <summary>
        /// Функция вычисляет маску с одним установоленным битом, чтобы отметить сгенерированную коньюнкцию. Если был сгенерирован 0, то вернет 1,
        /// так как надо отметить нулевую конъюнкцию. Если было сгенерировано 9, то вернет 2, так как 9 - это 2 бит!!! во втором байте, который можно заиликать 
        /// только 2 
        /// </summary>
        /// <param name="conjunction"></param>
        /// <returns></returns>
        public static byte GetCheckedBitrForConjunction(int conjunction)
        {
            return Convert.ToByte((1 << (conjunction % 8)));
        }

        /// <summary>
        /// Функция для генерации очередной конъюнкции
        /// </summary>
        /// <param name="countParameters">Количество параметров конънкции</param>
        /// <returns></returns>
        public static int GetRandomСonjunction(int countParameters)
        {
            return Random.Next((1 << countParameters) - 1);
        }

        public static int GetMask(int[] freeMembersIndex)
        {
            int mask = 0;
            for (int i = 0; i < freeMembersIndex.Length; i++)
            {
                int temp = 1 << freeMembersIndex[i];
                mask ^= temp;
            }

            return mask;
        }

        public static int GetRotateMask(int mask)
        {
            int rotateMask = 0;
            rotateMask ^= mask;
            return rotateMask;
        }
    }
}