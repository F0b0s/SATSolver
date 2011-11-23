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
        [Test, Repeat(100)]
        public void FindFreeMembersIndexTests()
        {
            const int countParam = 4;
            const int counrFreeMember = 2;

            var indexes = BinaryCounter.FindFreeMembersIndex(countParam, counrFreeMember);
            Assert.True(indexes.All(index => index < 4));
        }

        [Test]
        public void FindFreeMembersIndex_PassCountFreeEqualCountParam_ThrowArgumentException()
        {
            const int countParam = 4;
            const int counrFreeMember = 4;

            Assert.Throws<ArgumentException>( () => BinaryCounter.FindFreeMembersIndex(countParam, counrFreeMember));
        }

        [Test]
        public void FindFreeMembersIndex_PassCountFreeGreaterCountParam_ThrowArgumentException()
        {
            const int countParam = 4;
            const int counrFreeMember = 6;

            Assert.Throws<ArgumentException>(() => BinaryCounter.FindFreeMembersIndex(countParam, counrFreeMember));
        }

        [Test, Repeat(100)]
        public void GetBitNumberForConjunctionTest()
        {
            var rand = new Random();
            var conjunction = (uint)rand.Next(50);
            var result = BinaryCounter.GetCheckedBitrForConjunction(conjunction);

            Assert.AreEqual(Math.Pow(2, conjunction % 8), result);
        }

        [Test]
        public void FindSizeBitMapForCountParamsTests_PassCountParamsLess8()
        {
            const int countParams = 2;
            var size = BinaryCounter.FindSizeBitMapForCountParams(countParams);

            Assert.AreEqual(1, size);
        }

        [Test]
        public void FindSizeBitMapForCountParamsTests_PassCountParamsLess8_2()
        {
            const int countParams = 3;
            var size = BinaryCounter.FindSizeBitMapForCountParams(countParams);

            Assert.AreEqual(1, size);
        }

        [Test]
        public void FindSizeBitMapForCountParamsTests_PassCountParamsGreater8()
        {
            const int countParams = 10;
            var size = BinaryCounter.FindSizeBitMapForCountParams(countParams);

            Assert.AreEqual(128, size);
        }

        [Test]
        public void FindSizeBitMapForCountParamsTests_PassCountParamsDelete8()
        {
            const int countParams = 8;
            var size = BinaryCounter.FindSizeBitMapForCountParams(countParams);

            Assert.AreEqual(32, size);
        }

        [Test]
        public void GetCheckedBitrForConjunction_PassZero_MustReturn1()
        {
            const int conjunction = 0;
            Assert.AreEqual(1, BinaryCounter.GetCheckedBitrForConjunction(conjunction));
        }

        [Test]
        public void GetCheckedBitrForConjunction_Pass9_MustReturn2()
        {
            const int conjunction = 9;
            Assert.AreEqual(2, BinaryCounter.GetCheckedBitrForConjunction(conjunction));
        }

        [Test]
        public void GetCheckedBitrForConjunction_Pass15_MustReturn8()
        {
            const int conjunction = 15;
            Assert.AreEqual(128, BinaryCounter.GetCheckedBitrForConjunction(conjunction));
        }

        [Test]
        public void GetMask1()
        {
            int[] freeMemberIndex = new int[3]{1, 5, 12};
            const int expectedMask = 4130;
            var result = BinaryCounter.GetMask(freeMemberIndex);

            Assert.AreEqual(expectedMask, result);
        }

        [Test]
        public void GetMask2()
        {
            int[] freeMemberIndex = new int[1] { 22 };
            const int expectedMask = 4194304;
            var result = BinaryCounter.GetMask(freeMemberIndex);

            Assert.AreEqual(expectedMask, result);
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
        public void GetRotateMask()
        {
            const uint mask = 4194304;
            const uint expectedRotateMask = 4290772991;
            var result = BinaryCounter.GetRotateMask(mask);

            Assert.AreEqual(expectedRotateMask, result);
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