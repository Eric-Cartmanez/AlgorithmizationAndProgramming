using System.Collections.Generic;
using Tasks.Common;
using Tasks.TheLargestClass;
using Xunit;

namespace Tasks.Tests
{
    public class TheLargestClassTests
    {
        public static IEnumerable<object[]> GetSolutions()
        {
            yield return new object[] { new TheLargestClass.TheLargestClass() };
            yield return new object[] { new TheLargestClassAlt() };
            
        }

        // Объединяем решения и тестовые данные
        public static IEnumerable<object[]> GetTestScenario()
        {
            var solutions = GetSolutions();
            var data = GetTestData();

            foreach (var solution in solutions)
            {
                foreach (var testCase in data)
                {
                    yield return new object[] { solution[0], testCase[0], testCase[1] };
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetTestScenario))]
        public void RunTests(ITheLargestClassSolution solution, int[] inputStream, int expectedMaxGroupSize)
        {
            // Act
            var result = solution.Calculate(inputStream);

            // Assert
            Assert.Equal(expectedMaxGroupSize, result);
        }

        // Данные для тестов: [0] - входной поток (класс, школа...), [1] - ожидаемый результат
        public static IEnumerable<object[]> GetTestData()
        {
            // 1. Пример из скриншота: 
            // 4 ученика (8, 470), затем 6 учеников (10, 470), затем 2 ученика (8, 123). Максимум 6.
            yield return new object[] 
            { 
                new int[] { 
                    8, 470, 8, 470, 8, 470, 8, 470, 
                    10, 470, 10, 470, 10, 470, 10, 470, 10, 470, 10, 470, 
                    8, 123, 8, 123, 
                    0 
                }, 
                6 
            };

            // 2. Минимальный ввод: один ученик
            yield return new object[] 
            { 
                new int[] { 5, 1, 0 }, 
                1 
            };

            // 3. Одна группа из 3 человек
            yield return new object[] 
            { 
                new int[] { 5, 1, 5, 1, 5, 1, 0 }, 
                3 
            };

            // 4. Две группы: первая меньше (1 чел), вторая больше (2 чел)
            yield return new object[] 
            { 
                new int[] { 1, 1, 2, 2, 2, 2, 0 }, 
                2 
            };

            // 5. Две группы: первая больше (2 чел), вторая меньше (1 чел)
            yield return new object[] 
            { 
                new int[] { 1, 1, 1, 1, 2, 2, 0 }, 
                2 
            };

            // 6. Две группы одинакового размера (по 2 чел) -> результат 2
            yield return new object[] 
            { 
                new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 0 }, 
                2 
            };

            // 7. Один класс, но разные школы (группы разбиваются)
            yield return new object[] 
            { 
                new int[] { 9, 100, 9, 100, 9, 200, 0 }, 
                2 
            };

            yield return new object[] 
            { 
                new int[] { 9, 100, 9, 100, 10, 100, 0 }, 
                2 
            };

            yield return new object[] 
            { 
                new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 0 }, 
                3 
            };

            // 10. Три группы по возрастанию (1, 2, 3 человека)
            yield return new object[] 
            { 
                new int[] { 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 0 }, 
                3 
            };

            // 11. Три группы по убыванию (3, 2, 1 человека)
            yield return new object[] 
            { 
                new int[] { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 0 }, 
                3 
            };

            // 12. "Пила": группы 1 чел, 2 чел, 1 чел
            yield return new object[] 
            { 
                new int[] { 1, 1, 2, 2, 2, 2, 3, 3, 0 }, 
                2 
            };

            // 13. Много групп по 1 человеку (чередование)
            yield return new object[] 
            { 
                new int[] { 1, 1, 1, 2, 1, 3, 1, 4, 0 }, 
                1 
            };

            // 14. Длинная последовательность одной группы (10 человек)
            yield return new object[] 
            { 
                new int[] { 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 0 }, 
                10 
            };

            // 15. Проверка больших чисел в номере школы/класса (не должно влиять на подсчет)
            yield return new object[] 
            { 
                new int[] { 9999, 8888, 9999, 8888, 0 }, 
                2 
            };

            // 16. Сложный паттерн: 2, 1, 3, 1
            yield return new object[] 
            { 
                new int[] { 1,1, 1,1, 2,2, 3,3, 3,3, 3,3, 4,4, 0 }, 
                3 
            };

            // 17. Смена групп только по номеру школы
            // 5-1 (1 чел), 5-2 (2 чел), 5-1 (1 чел) -> рез 2
            yield return new object[] 
            { 
                new int[] { 5, 1, 5, 2, 5, 2, 5, 1, 0 }, 
                2 
            };

            // 18. Смена групп только по номеру класса
            // 5-1 (1 чел), 6-1 (2 чел), 5-1 (1 чел) -> рез 2
            yield return new object[] 
            { 
                new int[] { 5, 1, 6, 1, 6, 1, 5, 1, 0 }, 
                2 
            };

            // 19. Случай, когда максимум достигается в самой последней группе перед нулем
            yield return new object[] 
            { 
                new int[] { 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 0 }, 
                3 
            };
            
            // 20. Случай, когда максимум был в самой первой группе
            yield return new object[] 
            { 
                new int[] { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 0 }, 
                3 
            };
        }
    }
}
