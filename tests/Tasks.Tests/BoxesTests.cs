using System;
using System.Collections.Generic;
using Tasks.Boxes;
using Xunit;

namespace Tasks.Tests
{
    public class BoxesTests
    {
        // Метод поставки данных для тестов
        public static IEnumerable<object[]> GetTestCases()
        {
            var solutions = new IBoxesSolution[]
            {
                new Boxes.Boxes(),
                new Tasks.Boxes.BoxesAlternative()
            };

            var testCases = new (double a1, double b1, double c1, double a2, double b2, double c2, bool expected)[]
            {
                // 1. Влезает (без вращения)
                (1, 2, 3, 2, 3, 4, true),

                // 2. Не влезает (объем маловат)
                (5, 5, 5, 2, 2, 2, false),

                // 3. ВРАЩЕНИЕ: Коробка (5, 1, 1), Ящик (2, 6, 2)
                (5, 1, 1, 2, 6, 2, true),

                // 4. НЕ ВЛЕЗАЕТ: Одна сторона торчит
                (10, 1, 1, 5, 5, 5, false),

                // 5. Граничный случай: точное совпадение
                (3, 4, 5, 3, 4, 5, true),

                // 6. Точное совпадение, но цифры перепутаны местами
                (5, 4, 3, 3, 5, 4, true),

                // 7. Проверка Double (с точкой)
                (1.5, 2.5, 3.5, 1.5, 2.5, 3.5, true),

                (2.5, 3.5, 7.8, 8.1, 4, 3.1, true),

                (4, 2, 8, 10, 6, 6, true),

                (1, 3, 3, 2, 2, 4, false)
            };

            // Для каждой реализации — прогоняем все тест-кейсы
            foreach (var solution in solutions)
            {
                foreach (var (a1, b1, c1, a2, b2, c2, expected) in testCases)
                {
                    yield return new object[] { solution, a1, b1, c1, a2, b2, c2, expected };
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void IsBoxFit_WithoutArrays_ReturnsCorrectValue(
            IBoxesSolution solution,
            double a1, double b1, double c1,
            double a2, double b2, double c2,
            bool expected)
        {
            // Act
            bool actual = solution.IsBoxFit(a1, b1, c1, a2, b2, c2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
