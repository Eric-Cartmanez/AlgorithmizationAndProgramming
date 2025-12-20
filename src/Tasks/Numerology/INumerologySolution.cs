using Tasks.Common;

namespace Tasks.Numerology
{
    public interface INumerologySolution : ISolution
    {
        public int Calculate(int num);
    }
}
