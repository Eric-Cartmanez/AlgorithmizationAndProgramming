using System.Collections.Generic;
using Tasks.NumToText;
using Xunit;

namespace Tasks.Tests
{
    public class NumToTextTests
    {
        private static INumToTextSolution[] GetAllSolutions() => new INumToTextSolution[]
        {
            new Tasks.NumToText.NumToText(),
            new Tasks.NumToText.NumToTextAlternative()
        };

        public static IEnumerable<object[]> GetValidTestCases()
        {
            var cases = new (int n, string exp)[]
            {
                (1, "один"), (2, "два"), (10, "десять"),
                (20, "двадцать"), (21, "двадцать один"), (99, "девяносто девять")
            };

            foreach (var sol in GetAllSolutions())
            foreach (var (n, exp) in cases)
                yield return new object[] { sol, n, exp };
        }

        public static IEnumerable<object[]> GetInvalidTestCases()
        {
            var inputs = new int[] { 0, -5, 100, 200 };
            foreach (var sol in GetAllSolutions())
            foreach (var n in inputs)
                yield return new object[] { sol, n };
        }

        [Theory]
        [MemberData(nameof(GetValidTestCases))]
        public void Convert_WithValidInput_ReturnsCorrectText(
            INumToTextSolution solution, int number, string expected)
        {
            Assert.Equal(expected, solution.Convert(number), ignoreCase: true);
        }

        [Theory]
        [MemberData(nameof(GetInvalidTestCases))]
        public void Convert_WithInvalidInput_ReturnsError(
            INumToTextSolution solution, int number)
        {
            Assert.Equal("error", solution.Convert(number), ignoreCase: true);
        }
    }
}
