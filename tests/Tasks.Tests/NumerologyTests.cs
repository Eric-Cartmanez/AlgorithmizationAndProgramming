using System;
using System.Collections.Generic;
using Tasks.Numerology;
using Xunit;

namespace Tasks.Tests
{
    public class NumerologyTests
    {
        private static IEnumerable<object[]> GetSolutions()
        {
            yield return [new Tasks.Numerology.Numerology()];
        }

        public static IEnumerable<object[]> GetTestScenario()
        {
            var solutions = GetSolutions().ToArray();
            var data = GetTestData().ToArray();

            foreach (var solution in solutions)
            {
                foreach (var testCase in data)
                {
                    yield return [solution[0], testCase[0], testCase[1]];
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
            yield return new object[] { 10, 1 };        // 1+0 = 1
            yield return new object[] { 19, 1 };        // 1+9 = 10 → 1+0 = 1
            yield return new object[] { 99, 9 };        // 9+9 = 18 → 1+8 = 9
            yield return new object[] { 100, 1 };       // 1+0+0 = 1
            yield return new object[] { 123, 6 };       // 1+2+3 = 6
            yield return new object[] { 24121971, 9 };  // как в примере
            yield return new object[] { 19112008, 4 };  // 1+9+1+1+2+0+0+8 = 22 → 2+2 = 4
            yield return new object[] { 99999999, 9 };  // 8×9 = 72 → 7+2 = 9
            yield return new object[] { 567, 9 };       // 5+6+7 = 18 → 1+8 = 9
            yield return new object[] { 8, 8 };
            yield return new object[] { 999, 9 };       // 9+9+9 = 27 → 9
            yield return new object[] { 1000000000, 1 };// 1 + девять нулей → 1
            yield return new object[] { 123456789, 9 }; // сумма = 45 → 4+5 = 9
            yield return new object[] { 11, 2 };        // 1+1 = 2
            yield return new object[] { 1999, 1 };      // 1+9+9+9 = 28 → 10 → 1
            yield return new object[] { 2023, 7 };      // 2+0+2+3 = 7
            yield return new object[] { 2024, 8 };      // 2+0+2+4 = 8
            yield return new object[] { 777, 3 };       // 7+7+7 = 21 → 2+1 = 3
        }
    }
}
