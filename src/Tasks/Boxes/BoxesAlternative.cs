namespace Tasks.Boxes;

public class BoxesAlternative : IBoxesSolution
{
    public void Run()
    {
        //коробка
        double a1 = double.Parse(Console.ReadLine());
        double b1 = double.Parse(Console.ReadLine());
        double c1 = double.Parse(Console.ReadLine());
        //ящик
        double a2 = double.Parse(Console.ReadLine());
        double b2 = double.Parse(Console.ReadLine());
        double c2 = double.Parse(Console.ReadLine());

        bool isFit = IsBoxFit(a1, b1, c1, a2, b2, c2);

        Console.WriteLine(isFit ? "yes" : "no");
    }

    public bool IsBoxFit(double a1, double b1, double c1, double a2, double b2, double c2)
    {
        double min1 = a1 < b1 ? Math.Min(a1, c1) : Math.Min(b1, c1);
        double min2 = a2 < b2 ? Math.Min(a2, c2) : Math.Min(b2, c2);
        double max1 = a1 > b1 ? Math.Max(a1, c1) : Math.Max(b1, c1);
        double max2 = a2 > b2 ? Math.Max(a2, c2) : Math.Max(b2, c2);
        double mid1 = a1 + b1 + c1 - min1 - max1;
        double mid2 = a2 + b2 + c2 - min2 - max2;
        return min1 <= min2 && max1 <= max2 && mid1 <= mid2;
    }
}
