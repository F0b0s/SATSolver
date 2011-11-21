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

        public static IEnumerable<uint> RecoveredConjunction(uint mask, uint rotateMask, uint conjunction, int countFreeMembers)
        {
            uint currentConjunction = 0;
            for (uint i = 0; i < 1 << countFreeMembers; i++)
            {
                currentConjunction |= rotateMask; 
                currentConjunction++;
                currentConjunction &= mask;
                uint generatedConjunction = conjunction ^ currentConjunction;
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
        public static byte GetCheckedBitrForConjunction(uint conjunction)
        {
            return Convert.ToByte((1 << ((int)conjunction % 8)));
        }

        /// <summary>
        /// Функция для генерации очередной конъюнкции
        /// </summary>
        /// <param name="countParameters">Количество параметров конънкции</param>
        /// <returns></returns>
        public static uint GetRandomСonjunction(int countParameters)
        {
            return (uint)Random.Next((1 << countParameters) - 1);
        }

        public static uint GetMask(int[] freeMembersIndex)
        {
            uint mask = 0;
            for (int i = 0; i < freeMembersIndex.Length; i++)
            {
                uint temp = (uint)1 << freeMembersIndex[i];
                mask ^= temp;
            }

            return mask;
        }

        public static uint GetRotateMask(uint mask)
        {
            uint rotateMask = 0xFFFFFFFF;
            rotateMask ^= mask;
            return rotateMask;
        }
    }
}