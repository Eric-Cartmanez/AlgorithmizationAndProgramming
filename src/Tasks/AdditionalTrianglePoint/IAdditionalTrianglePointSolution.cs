using Tasks.Common;

namespace Tasks.AdditionalTrianglePoint
{
    public interface IAdditionalTrianglePointSolution : ISolution
    {
        public const string RES_INVALID = "Некоррeктный треугольник";
        public const string RES_INSIDE = "Треугольник содержит точку";
        public const string RES_OUTSIDE = "Треугольник не содержит точку";

        string Solve(Point a, Point b, Point c, Point p);
    }

    public struct Point
    {
        public double x;
        public double y;
    }
}
