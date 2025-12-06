using System;

using Tasks.Common;

namespace Tasks.WhileCarsDistance
{
    public class WhileCarsDistance : IWhileCarsDistanceSolution
    {

        public void Run()
        {
            // Console.WriteLine(Calculate(50, 55, 1.08, 1.02, 1000));
            // Console.WriteLine(Calculate(33, 60, 1.07, 0.97, 1500));

            if (!double.TryParse(Console.ReadLine(), out double speed1)
                || !double.TryParse(Console.ReadLine(), out double speed2)
                || !double.TryParse(Console.ReadLine(), out double diff1)
                || !double.TryParse(Console.ReadLine(), out double diff2)
                || !int.TryParse(Console.ReadLine(), out int s))
            {
                Console.WriteLine("incorrect input");
            }
            else
            {
                Console.WriteLine(Calculate(speed1, speed2, diff1, diff2, s));
            }
        }

        public int Calculate(double speed1, double speed2, double diff1, double diff2, int s)
        {
            double sumCarsDistance = 0;
            int halfHours = 0;

            while (sumCarsDistance < s)
            {
                halfHours++;
                sumCarsDistance += 0.5 * (speed1 + speed2);
                if (sumCarsDistance >= s) break;
                speed1 *= diff1;
                speed2 *= diff2;
            }

            int hours = (halfHours + 1) / 2;
            return hours;
        }
    }
}
