using System;
using Tasks.Common;

namespace Tasks.AdditionalTrianglePoint
{
    public class AdditionalTrianglePoint : IAdditionalTrianglePointSolution
    {
        public void Run()
        {
            try
            {
                Console.WriteLine("Введите точку A треугольника");
                getPointFromInput(out Point a);
                Console.WriteLine("Введите точку B треугольника");
                getPointFromInput(out Point b);
                Console.WriteLine("Введите точку C треугольника");
                getPointFromInput(out Point c);
                Console.WriteLine("Введите дополнительную точку");
                getPointFromInput(out Point p);

                Console.WriteLine(Solve(a, b, c, p));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string Solve(Point a, Point b, Point c, Point p)
        {
            if (!isCorrectTriangle(a, b, c))
            {
                return IAdditionalTrianglePointSolution.RES_INVALID;
            }

            return IsTriangleContainsPoint(a, b, c, p) 
                ? IAdditionalTrianglePointSolution.RES_INSIDE 
                : IAdditionalTrianglePointSolution.RES_OUTSIDE;
        }

        private bool IsTriangleContainsPoint(Point a, Point b, Point c, Point p, double epsilon = 0.0001)
        {
            double S = Square(a, b, c);
            double S1 = Square(a, b, p);
            double S2 = Square(a, c, p);
            double S3 = Square(b, c, p);

            return Math.Abs(S - (S1 + S2 + S3)) < epsilon;
        }

        private double Square(Point a, Point b, Point c)
        {
            return 0.5 * Math.Abs(a.x * (b.y - c.y) + b.x * (c.y - a.y) + c.x * (a.y - b.y));
        }

        private bool isCorrectTriangle(Point a, Point b, Point c, double epsilon = 0.0001)
        {
            double val1 = (b.y - a.y) * (c.x - a.x);
            double val2 = (b.x - a.x) * (c.y - a.y);
            
            return Math.Abs(val1 - val2) > epsilon;
        }

        private void getPointFromInput(out Point p)
        {
            if (!double.TryParse(Console.ReadLine(), out double x) || !double.TryParse(Console.ReadLine(), out double y))
            {
                throw new Exception("Incorrect input");
            }
            p = new Point { x = (int)x, y = (int)y };
        }
    }
}
