using Tasks.Common;

namespace Tasks.WhileCarsDistance
{
    public interface IWhileCarsDistanceSolution : ISolution
    {
        int Calculate(double speed1, double speed2, double diff1, double diff2, int s);
    }
}
