using System;

using Tasks.Common;

namespace Tasks.VowelOrConsonant
{
    public class VowelOrConsonant : IVowelOrConsonantSolution
    {
        public void Run()
        {   
            char l;
            string input = Console.ReadLine();
            if (!char.TryParse(input.ToLower(), out l)) {
                Console.WriteLine("Error");
                return;
            }
            Console.WriteLine(DetermineLetter(l));
        }

        public string DetermineLetter(char l)
        {
            char lowerL = char.ToLower(l);
            if (!((lowerL >= 'а' && lowerL <= 'я') || lowerL == 'ё'))
            {
                return "Error";
            }
            switch (lowerL)
            {
                case 'а':
                case 'о':
                case 'у': 
                case 'и': 
                case 'е': 
                case 'я': 
                case 'э':
                case 'ё': 
                case 'ы': 
                case 'ю': 
                    return "Гласная";
                default: return "Согласная";
            }
        }
    }
}