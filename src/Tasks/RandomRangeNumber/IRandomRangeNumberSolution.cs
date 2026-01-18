using Tasks.Common;

namespace Tasks.RandomRangeNumber
{
    public interface IRandomRangeNumberSolution : ISolution
    {
        uint GetNumber(uint d, uint min, uint max);
    }
}
