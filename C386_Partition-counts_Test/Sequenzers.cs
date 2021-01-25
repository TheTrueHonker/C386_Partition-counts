using Microsoft.VisualStudio.TestTools.UnitTesting;
using C386_Partition_counts.Sequencers;
using System.Numerics;

namespace C386_Partition_counts_Test
{
    [TestClass]
    public class Sequenzers
    {
        private Counter positivCounter;
        private Counter negativeCounter;
        private Alternator alternator;

        [TestInitialize]
        public void Setup()
        {
            positivCounter = new Counter(1, 1);
            negativeCounter = new Counter(-1, -1);
            alternator = new Alternator();
        }

        [TestCategory("Counter")]
        [TestMethod]
        public void TestPositivCounter()
        {
            long firstValueLoc = positivCounter.GetNext();
            long secondValueLoc = positivCounter.GetNext();
            positivCounter.Reset();
            long afterResetLoc = positivCounter.GetNext();

            long expectedFirstValueLoc = 1;
            long expectedSecondValueLoc = 2;
            long expectedAfterReset = 1;

            Assert.AreEqual(expectedFirstValueLoc, firstValueLoc);
            Assert.AreEqual(expectedSecondValueLoc, secondValueLoc);
            Assert.AreEqual(expectedAfterReset, afterResetLoc);
        }

        [TestCategory("Counter")]
        [TestMethod]
        public void TestNegativCounter()
        {
            long firstValueLoc = negativeCounter.GetNext();
            long secondValueLoc = negativeCounter.GetNext();
            negativeCounter.Reset();
            long afterResetLoc = negativeCounter.GetNext();

            long expectedFirstValueLoc = -1;
            long expectedSecondValueLoc = -2;
            long expectedAfterReset = -1;

            Assert.AreEqual(expectedFirstValueLoc, firstValueLoc);
            Assert.AreEqual(expectedSecondValueLoc, secondValueLoc);
            Assert.AreEqual(expectedAfterReset, afterResetLoc);
        }

        [TestCategory("Alternator")]
        [TestMethod]
        public void TestAlternator()
        {
            long firstValueLoc = alternator.GetNext();
            long secondValueLoc = alternator.GetNext();
            long thirdValueLoc = alternator.GetNext();
            long fourthValueLoc = alternator.GetNext();
            long fifthValueLoc = alternator.GetNext();
            alternator.Reset();
            long afterReset = alternator.GetNext();

            long expectedFirstValueLoc = 1;
            long expectedSecondValueLoc = 3;
            long expectedThirdValueLoc = 2;
            long expectedFourthValueLoc = 5;
            long expectedFifthValueLoc = 3;
            long expectedAfterReset = 1;

            Assert.AreEqual(expectedFirstValueLoc, firstValueLoc);
            Assert.AreEqual(expectedSecondValueLoc, secondValueLoc);
            Assert.AreEqual(expectedThirdValueLoc, thirdValueLoc);
            Assert.AreEqual(expectedFourthValueLoc, fourthValueLoc);
            Assert.AreEqual(expectedFifthValueLoc, fifthValueLoc);
            Assert.AreEqual(expectedAfterReset, afterReset);
        }

        [TestCategory("Partitioner")]
        [TestMethod]
        public void TestPartitioner()
        {
            BigInteger p0 = Partitioner.GetPossibilities(0);
            BigInteger p1 = Partitioner.GetPossibilities(1);
            BigInteger p2 = Partitioner.GetPossibilities(2);
            BigInteger p11 = Partitioner.GetPossibilities(11);

            BigInteger expectedP0 = 1;
            BigInteger expectedP1 = 1;
            BigInteger expectedP2 = 2;
            BigInteger expectedP11 = 56;

            Assert.AreEqual(expectedP0, p0);
            Assert.AreEqual(expectedP1, p1);
            Assert.AreEqual(expectedP2, p2);
            Assert.AreEqual(expectedP11, p11);
        }
    }
}
