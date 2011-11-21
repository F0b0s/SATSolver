using System;
using System.Collections;
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
        [Test, Repeat(100)]
        public void GetBitNumberForConjunctionTest()
        {
            var rand = new Random();
            var conjunction = (uint)rand.Next(50);
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
            uint mask = 0x07;  //0x00000111
            uint rotatedMask = 0xF8;//0x11111000
            uint conjunction = 8;
            int countFreeMembers = 3;

            var expectedConjunctions = new List<uint>(){8, 9, 10, 11, 12, 13, 14, 15};
            var list = new List<uint>();
            foreach (var i in BinaryCounter.RecoveredConjunction(mask, rotatedMask, conjunction, countFreeMembers))
            {
                Debug.WriteLine(i);
                list.Add(i);
            }

            Assert.True(expectedConjunctions.All(list.Contains));
        }
        
        [Test]
        public void RecoveredConjunctionTests2()
        {
            uint mask = 0x05;  //0x00000101
            uint rotatedMask = 0xFA;//0x11111010
            uint conjunction = 8;
            int countFreeMembers = 2;

            var expectedConjunctions = new List<uint>() { 8, 9, 12, 13 };
            var list = new List<uint>();
            foreach (var i in BinaryCounter.RecoveredConjunction(mask, rotatedMask, conjunction, countFreeMembers))
            {
                list.Add(i);
            }

            Assert.True(expectedConjunctions.All(list.Contains));
        }

        [Test]
        public void GetRotateMaskTest()
        {
            uint mask = 0x07;
            uint rotateMask = 0xFFFFFFF8;

            var result = BinaryCounter.GetRotateMask(mask);

            Assert.AreEqual(rotateMask, result);

        }
    }
}