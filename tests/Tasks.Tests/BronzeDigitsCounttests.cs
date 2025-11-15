using System;
using System.Collections.Generic;
using Tasks.BronzeDigitsCount;
using Xunit;

namespace Tasks.Tests
{
    public class BronzeDigitsCountTests
    {
        public static IEnumerable<object[]> GetSolutions()
        {
            yield return new object[] { new BronzeDigitsCount.BronzeDigitsCount() };
        }

        // Используем [Theory] и [InlineData] для проверки нескольких случаев одним тестом
        [Theory]
        [MemberData(nameof(GetSolutions))]
        public void Calculate_WithValidInputs_ReturnsCorrectValue(IBronzeDigitsCount solution)
        {
            Assert.Equal(5, solution.Calculate(5));       // Однозначные числа
            Assert.Equal(9, solution.Calculate(9));       // Граница 1
            Assert.Equal(11, solution.Calculate(10));     // Граница 2
            Assert.Equal(189, solution.Calculate(99));    // Граница 3
            Assert.Equal(192, solution.Calculate(100));   // Граница 4
            Assert.Equal(2889, solution.Calculate(999));  // Максимальное значение
        }

        [Theory]
        [MemberData(nameof(GetSolutions))]
        public void Calculate_WithInvalidInputs(IBronzeDigitsCount solution)
        {   
            Assert.Equal(-1, solution.Calculate(0));
            Assert.Equal(-1, solution.Calculate(1000));
            Assert.Equal(-1, solution.Calculate(-10));
        }
    }
}