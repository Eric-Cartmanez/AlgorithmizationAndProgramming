using System;
using System.Collections.Generic;
using Tasks.NumToText;
using Xunit;

namespace Tasks.Tests
{
    public class NumToTextTests
    {
        // Генератор валидных тестовых случаев
        public static IEnumerable<object[]> GetValidTestCases()
        {
            var solution = new Tasks.NumToText.NumToText();

            // --- 1. Единицы (1-9) ---
            yield return new object[] { solution, 1, "один" };
            yield return new object[] { solution, 2, "два" };
            yield return new object[] { solution, 3, "три" };
            yield return new object[] { solution, 4, "четыре" };
            yield return new object[] { solution, 5, "пять" };
            yield return new object[] { solution, 6, "шесть" };
            yield return new object[] { solution, 7, "семь" };
            yield return new object[] { solution, 8, "восемь" };
            yield return new object[] { solution, 9, "девять" };

            // --- 2. Числа от 10 до 19 (особые случаи) ---
            yield return new object[] { solution, 10, "десять" };
            yield return new object[] { solution, 11, "одиннадцать" };
            yield return new object[] { solution, 12, "двенадцать" }; // Пример из условия
            yield return new object[] { solution, 13, "тринадцать" };
            yield return new object[] { solution, 14, "четырнадцать" };
            yield return new object[] { solution, 15, "пятнадцать" };
            yield return new object[] { solution, 16, "шестнадцать" };
            yield return new object[] { solution, 17, "семнадцать" };
            yield return new object[] { solution, 18, "восемнадцать" };
            yield return new object[] { solution, 19, "девятнадцать" };

            // --- 3. Круглые десятки ---
            yield return new object[] { solution, 20, "двадцать" };
            yield return new object[] { solution, 30, "тридцать" };
            yield return new object[] { solution, 40, "сорок" };
            yield return new object[] { solution, 50, "пятьдесят" };
            yield return new object[] { solution, 60, "шестьдесят" };
            yield return new object[] { solution, 70, "семьдесят" };
            yield return new object[] { solution, 80, "восемьдесят" };
            yield return new object[] { solution, 90, "девяносто" };

            // --- 4. Составные числа (Десятки + Единицы) ---
            yield return new object[] { solution, 21, "двадцать один" };
            yield return new object[] { solution, 25, "двадцать пять" };
            yield return new object[] { solution, 33, "тридцать три" };
            yield return new object[] { solution, 47, "сорок семь" }; // Пример из условия
            yield return new object[] { solution, 58, "пятьдесят восемь" };
            yield return new object[] { solution, 64, "шестьдесят четыре" };
            yield return new object[] { solution, 72, "семьдесят два" };
            yield return new object[] { solution, 89, "восемьдесят девять" };
            yield return new object[] { solution, 96, "девяносто шесть" };
            
            // Граничный случай - максимальное валидное
            yield return new object[] { solution, 99, "девяносто девять" };
        }

        // Генератор невалидных тестовых случаев
        public static IEnumerable<object[]> GetInvalidTestCases()
        {
            var solution = new Tasks.NumToText.NumToText();

            // Меньше 1
            yield return new object[] { solution, 0 };
            yield return new object[] { solution, -1 };
            yield return new object[] { solution, -50 };
            yield return new object[] { solution, int.MinValue };

            // Больше 99
            yield return new object[] { solution, 100 };
            yield return new object[] { solution, 101 };
            yield return new object[] { solution, 1000 };
            yield return new object[] { solution, int.MaxValue };
        }

        [Theory]
        [MemberData(nameof(GetValidTestCases))]
        public void Convert_WithValidRange_ReturnsRussinText(INumToTextSolution solution, int number, string expectedText)
        {
            // Act
            string result = solution.Convert(number);

            // Assert
            // Используем ignoreCase: true, так как в условии сказано "Регистр символов... можно не настраивать"
            Assert.Equal(expectedText, result, ignoreCase: true);
        }

        [Theory]
        [MemberData(nameof(GetInvalidTestCases))]
        public void Convert_WithInvalidRange_ReturnsError(INumToTextSolution solution, int number)
        {
            // Act
            string result = solution.Convert(number);

            // Assert
            Assert.Equal("error", result, ignoreCase: true);
        }
    }
}
