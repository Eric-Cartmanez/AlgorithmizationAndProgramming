using Tasks.MathCalculations;
using Xunit;

namespace Tasks.Tests
{
    public class MathCalculationsTests
    {
        [Fact]
        public void Calculate_WithPositiveInput_ReturnsCorrectValue()
        {
            var calculator = new MathCalculations.MathCalculations();
            double a = 5;
            double expected = 1.730;

            double actual = calculator.Calculate(a);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculate_WithInputCausingNegativeSqrt_ReturnsNaN()
        {
            // Arrange
            var calculator = new MathCalculations.MathCalculations();
            double a = -10;

            // Act
            double actual = calculator.Calculate(a);

            // Assert
            Assert.True(double.IsNaN(actual)); 
        }

        [Fact]
        public void Calculate_WithZeroInput_ReturnsZero()
        {
            // Arrange
            var calculator = new MathCalculations.MathCalculations();
            double a = 0;
            double expected = 0;

            // Act
            double actual = calculator.Calculate(a);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}