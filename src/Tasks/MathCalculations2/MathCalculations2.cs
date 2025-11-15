using System;

using Tasks.Common;

namespace Tasks.MathCalculations2
{
    public class MathCalculations2 : IMathCalculations2Solution
    {
        public void Run()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine(Calculate(a, b));
        }

        public double Calculate(double a, double b)
        {
            double numerator = 2.0 / (a * a + 25) + b;
            double denominator = Math.Sqrt(b) + (a + b) / 2.0;
            return Math.Round(numerator / denominator, 3);
        }
    }
}