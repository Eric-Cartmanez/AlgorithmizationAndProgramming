using System;
using System.Collections.Generic;
using System.Linq; 
using Tasks.Numerology;
using Xunit;

namespace Tasks.Tests
{
    public class NumerologyTests
    {
        public static IEnumerable<object[]> GetSolutions()
        {
            yield return new object[] { new Tasks.Numerology.Numerology() };
            yield return new object[] { new Tasks.Numerology.NumerologyAlt() };
        }

        public static IEnumerable<object[]> GetTestScenario()
        {
            var solutions = GetSolutions().ToList();
            var data = GetTestData().ToList();

            foreach (var solutionArr in solutions)
            {
                var solutionInstance = solutionArr[0];

                foreach (var testCase in data)
                {
                    yield return new object[] { solutionInstance, testCase[0], testCase[1] };
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetTestScenario))]
        public void RunTests(INumerologySolution solution, int input, int expected)
        {
            // Act
            var result = solution.Calculate(input);

            // Assert
            Assert.Equal(expected, result);
        }

        private static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 1, 1 };
            yield return new object[] { 9, 9 };
            yield return new object[] { 8, 8 };
            
            yield return new object[] { 10, 1 };        // 1+0 = 1
            yield return new object[] { 11, 2 };        // 1+1 = 2
            yield return new object[] { 19, 1 };        // 1+9 = 10 → 1+0 = 1
            yield return new object[] { 91, 1 };        // 9+1 = 10 -> 1
            yield return new object[] { 99, 9 };        // 9+9 = 18 → 1+8 = 9
            
            yield return new object[] { 100, 1 };       // 1+0+0 = 1
            yield return new object[] { 123, 6 };       // 1+2+3 = 6
            yield return new object[] { 567, 9 };       // 5+6+7 = 18 → 1+8 = 9
            yield return new object[] { 777, 3 };       // 7+7+7 = 21 → 2+1 = 3
            yield return new object[] { 999, 9 };       // 9+9+9 = 27 → 9

            yield return new object[] { 24121971, 9 };  // Пример из задачи
            yield return new object[] { 19112008, 4 };  // 1+9+1+1+2+0+0+8 = 22 → 4
            yield return new object[] { 2023, 7 };      // 2+0+2+3 = 7
            yield return new object[] { 2024, 8 };      // 2+0+2+4 = 8
            yield return new object[] { 1999, 1 };      // 1+9+9+9 = 28 → 10 → 1
            
            yield return new object[] { 99999999, 9 };  // 8×9 = 72 → 9
            yield return new object[] { 1000000000, 1 };// 1 + девять нулей → 1
            yield return new object[] { 123456789, 9 }; // Сумма = 45 → 9
            
            yield return new object[] { 2147483647, 1 }; // Сложите сами: 46 -> 10 -> 1
        }
    }
}
