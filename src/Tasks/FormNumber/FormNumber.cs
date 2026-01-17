using System;
using System.Security.Cryptography.X509Certificates;
using Tasks.Common;

namespace Tasks.FormNumber
{
    public class FormNumber : IFormNumberSolution
    {
        public void Run()
        {
            Console.WriteLine("Введите число num");
            string input = Console.ReadLine();
            if (!uint.TryParse(input, out uint num)) {
                return;
            }
            Console.WriteLine("Введите число a");
            input = Console.ReadLine();
            if (!uint.TryParse(input, out uint a)) {
                return;
            }
            Console.WriteLine("Введите число b");
            input = Console.ReadLine();
            if (!uint.TryParse(input, out uint b)) {
                return;
            }
            Console.WriteLine(FindPathToNumber(num, a, b));
        }

        public string FindPathToNumber(uint num, uint a, uint b)
        {
            if (num == 1) return "";
            if (num <= 0) return IFormNumberSolution.ERROR_MESSAGE;

            if (b > 1 && num % b == 0)
            {
                string path = FindPathToNumber(num / b, a, b);
                if (path != IFormNumberSolution.ERROR_MESSAGE)
                    return path + $" *{b}";
            }

            if (num > a && a != 0)
            {
                string path = FindPathToNumber(num - a, a, b);
                if (path != IFormNumberSolution.ERROR_MESSAGE)
                    return path + $" +{a}";
            }

            return IFormNumberSolution.ERROR_MESSAGE;
        }
    }
}
