using System;
using Xunit;
using Tasks.GraphFunctionConsonat;

namespace Tasks.Tests
{
    public class GraphFunctionConsonatTests
    {
        private readonly GraphFunctionConsonat.GraphFunctionConsonat _solver 
            = new GraphFunctionConsonat.GraphFunctionConsonat();

        [Theory]
        [InlineData(0,   -1)]
        [InlineData(1,    0)]
        [InlineData(2,   -1)]
        [InlineData(3,    0)]
        [InlineData(4,   -1)]
        [InlineData(-1,   0)]
        [InlineData(-2,  -1)]
        [InlineData(-3,   0)]
        public void BasicPoints_CheckMinAndMax(double x, double expected)
        {
            Assert.Equal(expected, _solver.F(x), 6);
        }

        [Theory]
        [InlineData(1.7, -0.7)]
        [InlineData(-2.2, -0.8)]
        [InlineData(1.3, -0.3)]
        [InlineData(0.5, -0.5)]
        [InlineData(-0.5, -0.5)]
        [InlineData(-0.8, -0.2)]
        [InlineData(0.9, -0.1)]
        public void IntermediatePoints_CheckLinearSegments(double x, double expected)
        {
            Assert.Equal(expected, _solver.F(x), 6);
        }

        [Theory]
        [InlineData(0.3)]
        [InlineData(1.2)]
        [InlineData(-0.8)]
        public void Symmetry_CheckEvenFunction(double x)
        {
            Assert.Equal(_solver.F(x), _solver.F(-x), 6);
        }

        [Theory]
        [InlineData(0.3)]
        [InlineData(1.7)]
        [InlineData(-1.4)]
        public void Periodicity_CheckPeriodIsTwo(double x)
        {
            Assert.Equal(_solver.F(x), _solver.F(x + 2), 6);
            Assert.Equal(_solver.F(x), _solver.F(x - 2), 6);
        }

        [Theory]
        [InlineData(100.3)]
        [InlineData(-100.3)]
        [InlineData(1000.7)]
        public void LargeValues_CheckRepetition(double x)
        {
            Assert.Equal(_solver.F(x), _solver.F(x % 2), 6);
        }

        [Theory]
        [InlineData(double.Epsilon, -1)]
        [InlineData(2.0, -1)]
        [InlineData(-2.0, -1)]
        public void BorderCases_CheckLimits(double x, double expected)
        {
            Assert.Equal(expected, _solver.F(x), 6);
        }
    }
}
