using System;
using System.Diagnostics;
using NUnit.Framework;
using SatSolver.BinaryCounter;

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
            var binaryCounter = new BinaryCounter();
            var result = binaryCounter.GetCheckedBitrForConjunction(conjunction);

            Assert.AreEqual(Math.Pow(2, conjunction % 8), result);
        }
    }
}