using System;
using System.Collections.Generic;
using Tasks.MathCalculations2;
using Xunit;

namespace Tasks.Tests
{
    public class MathCalculations2Tests
    {
        public static IEnumerable<object[]> GetSolutions()
        {
            yield return new object[] { new Tasks.MathCalculations2.MathCalculations2() };
        }

        [Theory]
        [MemberData(nameof(GetSolutions))]
        public void Calculate_WithValidInputs_ReturnsCorrectValue(IMathCalculations2Solution solution)
        {
            double a = 5;
            double b = 3;
            // Calculate expected value for MathCalculations2
            double numerator = 2.0 / (a * a + 25) + b;
            double denominator = Math.Sqrt(b) + (a + b) / 2.0;
            double expected = Math.Round(numerator / denominator, 3);

            double actual = solution.Calculate(a, b);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetSolutions))]
        public void Calculate_WithAnotherInputs_ReturnsCorrectValue(IMathCalculations2Solution solution)
        {
            double a = 1;
            double b = 4;
            double numerator = 2.0 / (a * a + 25) + b;
            double denominator = Math.Sqrt(b) + (a + b) / 2.0;
            double expected = Math.Round(numerator / denominator, 3);

            double actual = solution.Calculate(a, b);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetSolutions))]
        public void Calculate_WithZeroB_ReturnsCorrectValue(IMathCalculations2Solution solution)
        {
            double a = 2;
            double b = 0;
            double numerator = 2.0 / (a * a + 25) + b;
            double denominator = Math.Sqrt(b) + (a + b) / 2.0;
            double expected = Math.Round(numerator / denominator, 3);

            double actual = solution.Calculate(a, b);

            Assert.Equal(expected, actual);
        }
    }
}