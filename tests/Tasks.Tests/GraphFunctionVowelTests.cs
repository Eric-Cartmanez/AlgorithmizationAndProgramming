using System;
using System.Collections.Generic;
using Tasks.GraphFunctionVowel;
using Xunit;

namespace Tasks.Tests
{
    public class GraphFunctionVowelTests
    {
        // Метод генерирует данные для тестов: [Экземпляр класса, Входное значение, Ожидаемый результат]
        public static IEnumerable<object[]> GetTestCases()
        {
            var solution = new Tasks.GraphFunctionVowel.GraphFunctionVowel();

            // --- Группа 1: Примеры из условия ---
            yield return new object[] { solution, 1.7, 0.3 };
            yield return new object[] { solution, -2.2, 0.2 };
            yield return new object[] { solution, 0.0, 0.0 };

            // --- Группа 2: Целые узловые точки (нули и пики) ---
            // В точках 0, 2, 4... значение 0
            yield return new object[] { solution, 2.0, 0.0 };
            yield return new object[] { solution, 4.0, 0.0 };
            yield return new object[] { solution, 100.0, 0.0 }; // Проверка далекого периода
            
            // В точках 1, 3, 5... значение 1
            yield return new object[] { solution, 1.0, 1.0 };
            yield return new object[] { solution, 3.0, 1.0 };
            yield return new object[] { solution, 11.0, 1.0 };

            // --- Группа 3: Отрицательные значения (симметрия) ---
            // В точках -2, -4... значение 0
            yield return new object[] { solution, -2.0, 0.0 };
            // В точках -1, -3... значение 1
            yield return new object[] { solution, -1.0, 1.0 };
            
            // --- Группа 4: Проверка линейности (серединные значения) ---
            // При x=0.5 y должен быть 0.5 (рост)
            yield return new object[] { solution, 0.5, 0.5 };
            // При x=1.5 y должен быть 0.5 (спад)
            yield return new object[] { solution, 1.5, 0.5 };
            // Симметрия для отрицательных
            yield return new object[] { solution, -0.5, 0.5 };
            yield return new object[] { solution, -1.5, 0.5 };

            // --- Группа 5: Граничные значения и точность ---
            // Чуть больше 0
            yield return new object[] { solution, 0.1, 0.1 };
            // Чуть меньше 2
            yield return new object[] { solution, 1.9, 0.1 };
            // Сложный отрицательный кейс
            // x=-2.2 (это 0.2 от -2 влево), y=0.2. 
            // x=-2.8 (это 0.2 от -3 вправо, пик в -3 равен 1, значит спуск на 0.2 -> 0.8)
            yield return new object[] { solution, -2.8, 0.8 };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void CheckFunctionLogic(IGraphFunctionVowelSolution solution, double x, double expected)
        {
            // Act
            // Предполагается, что метод называется F. Если Run или Calculate - поправь здесь.
            double actual = solution.F(x);

            // Assert
            // Используем точность до 5 знаков, чтобы избежать ошибок плавающей точки
            Assert.Equal(expected, actual, 5);
        }
    }
}

