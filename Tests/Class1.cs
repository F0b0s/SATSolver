using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using SatSolver.BinaryCounter;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            int variableCount = 3;
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int rand = rnd.Next();
                int del = (((int) 1) << variableCount);
                int num5 = rand % del;
                Debug.WriteLine(num5);
            }
            Console.ReadLine();
        }

        [Test, Repeat(100)]
        public void GetBitNumberForConjunctionTest()
        {
            var rand = new Random();
            var conjunction = rand.Next(50);
            var result = BinaryCounter.GetCheckedBitrForConjunction(conjunction);

            Assert.AreEqual(Math.Pow(2, conjunction % 8), result);
        }

        [Test]
        public void FindSizeBitMapForCountParamsTests()
        {
            const int countParams = 2;
            var size = BinaryCounter.FindSizeBitMapForCountParams(countParams);

            Assert.AreEqual(1, size);
        }

        [Test]
        public void RecoveredConjunctionTests()
        {
            int mask = 0x00010101;
            int rotatedMask = 0x11101010;
            int conjunction = 16;
            int countFreeMembers = 3;

            var expectedConjunctions = new List<int>(){144, 176, 152, 16, 48, 24, 56};
            var result = BinaryCounter.RecoveredConjunction(mask, rotatedMask, conjunction, countFreeMembers);
            var resultConjunctions = new List<int>(result);
            Assert.True(expectedConjunctions.All(resultConjunctions.Contains));

        }
    }
}