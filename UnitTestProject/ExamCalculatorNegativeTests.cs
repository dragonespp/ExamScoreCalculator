using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExamScoreCalculator
{
    [TestClass]
    public class ExamCalculatorNegativeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateResult_Module1Negative_ThrowsException()
        {
            int m1 = -1, m2 = 0, m3 = 0;
            ExamCalculator.CalculateResult(m1, m2, m3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateResult_Module1OverMax_ThrowsException()
        {
            int m1 = 23, m2 = 0, m3 = 0;
            ExamCalculator.CalculateResult(m1, m2, m3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateResult_Module2Negative_ThrowsException()
        {
            int m1 = 0, m2 = -1, m3 = 0;
            ExamCalculator.CalculateResult(m1, m2, m3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateResult_Module2OverMax_ThrowsException()
        {
            int m1 = 0, m2 = 39, m3 = 0;
            ExamCalculator.CalculateResult(m1, m2, m3);
        }
    }
}
