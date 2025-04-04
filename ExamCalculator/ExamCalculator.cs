using System;

namespace ExamScoreCalculator
{
    public class ExamCalculator
    {
        public const int MaxModule1 = 22;
        public const int MaxModule2 = 38;
        public const int MaxModule3 = 20;
        public const int MaxTotal = MaxModule1 + MaxModule2 + MaxModule3;

        public static (int total, string grade) CalculateResult(int module1, int module2, int module3)
        {
            if (module1 < 0 || module1 > MaxModule1)
                throw new ArgumentOutOfRangeException(nameof(module1), $"Модуль 1 должен быть между 0 и {MaxModule1}");

            if (module2 < 0 || module2 > MaxModule2)
                throw new ArgumentOutOfRangeException(nameof(module2), $"Модуль 2 должен быть между 0 и {MaxModule2}");

            if (module3 < 0 || module3 > MaxModule3)
                throw new ArgumentOutOfRangeException(nameof(module3), $"Модуль 3 должен быть между 0 и {MaxModule3}");

            int total = module1 + module2 + module3;
            string grade = CalculateGrade(total);

            return (total, grade);
        }

        public static string CalculateGrade(int totalScore)
        {
            if (totalScore >= 56 && totalScore <= 80) return "5 (отлично)";
            if (totalScore >= 32 && totalScore <= 55) return "4 (хорошо)";
            if (totalScore >= 16 && totalScore <= 31) return "3 (удовлетворительно)";
            return "2 (неудовлетворительно)";
        }
    }
}