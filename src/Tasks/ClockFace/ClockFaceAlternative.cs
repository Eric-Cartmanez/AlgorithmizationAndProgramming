namespace Tasks.ClockFace;

public class ClockFaceAlternative : IClockFaceSolution
{
    public void Run()
    {
        byte hours = byte.Parse(Console.ReadLine());
        byte minutes = byte.Parse(Console.ReadLine());
        byte seconds = byte.Parse(Console.ReadLine());

        double degree = Calculate(hours, minutes, seconds);

        Console.WriteLine(degree);
    }

    private double GetDegreePerSec()
    {
        // за 3 часа имеем 90 градусов
        return 90d / (3 * 3600);
    }

    public double Calculate(int hours, int minuites, int seconds)
    {
        int secondsSum = hours * 3600 + minuites * 60 + seconds;
        return Math.Round(secondsSum * GetDegreePerSec(), 3);
    }
}
