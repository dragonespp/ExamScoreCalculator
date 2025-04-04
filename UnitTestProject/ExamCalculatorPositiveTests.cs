using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamScoreCalculator
{
    [TestClass]
    public class ExamCalculatorPositiveTests
    {
        [TestMethod]
        public void CalculateResult_MinValues_ReturnsCorrectResult()
        {
            int m1 = 0, m2 = 0, m3 = 0;
            int expectedTotal = 0;
            string expectedGrade = "2 (неудовлетворительно)";

            var (total, grade) = ExamCalculator.CalculateResult(m1, m2, m3);

            Assert.AreEqual(expectedTotal, total);
            Assert.AreEqual(expectedGrade, grade);
        }

        [TestMethod]
        public void CalculateResult_MaxValues_ReturnsCorrectResult()
        {
            int m1 = 22, m2 = 38, m3 = 20;
            int expectedTotal = 80;
            string expectedGrade = "5 (отлично)";

            var (total, grade) = ExamCalculator.CalculateResult(m1, m2, m3);

            Assert.AreEqual(expectedTotal, total);
            Assert.AreEqual(expectedGrade, grade);
        }

        [TestMethod]
        public void CalculateResult_BorderBetween3And4_ReturnsCorrectResult()
        {
            int m1 = 15, m2 = 15, m3 = 1;
            int expectedTotal = 31;
            string expectedGrade = "3 (удовлетворительно)";

            var (total, grade) = ExamCalculator.CalculateResult(m1, m2, m3);

            Assert.AreEqual(expectedTotal, total);
            Assert.AreEqual(expectedGrade, grade);
        }

        [TestMethod]
        public void CalculateResult_BorderBetween4And5_ReturnsCorrectResult()
        {
            int m1 = 20, m2 = 20, m3 = 15;
            int expectedTotal = 55;
            string expectedGrade = "4 (хорошо)";

            var (total, grade) = ExamCalculator.CalculateResult(m1, m2, m3);

            Assert.AreEqual(expectedTotal, total);
            Assert.AreEqual(expectedGrade, grade);
        }

        [TestMethod]
        public void CalculateGrade_Score15_Returns2()
        {
            int score = 15;
            string expected = "2 (неудовлетворительно)";

            string result = ExamCalculator.CalculateGrade(score);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateGrade_Score16_Returns3()
        {
            int score = 16;
            string expected = "3 (удовлетворительно)";

            string result = ExamCalculator.CalculateGrade(score);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateGrade_Score32_Returns4()
        {
            int score = 32;
            string expected = "4 (хорошо)";

            string result = ExamCalculator.CalculateGrade(score);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateGrade_Score56_Returns5()
        {
            int score = 56;
            string expected = "5 (отлично)";

            string result = ExamCalculator.CalculateGrade(score);

            Assert.AreEqual(expected, result);
        }
    }
}
