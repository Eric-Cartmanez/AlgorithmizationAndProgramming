using Tasks.Common;

namespace Tasks.FormNumber
{
    public interface IFormNumberSolution : ISolution
    {
        public const string ERROR_MESSAGE = "Невозможно построить путь";
        public string FindPathToNumber(uint num, uint a, uint b);
    }
}
