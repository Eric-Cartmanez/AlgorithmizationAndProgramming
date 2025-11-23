using Tasks.Common;

namespace Tasks.VowelOrConsonant
{
    public interface IVowelOrConsonantSolution : ISolution
    {
        public string DetermineLetter(char l);
    }
}
