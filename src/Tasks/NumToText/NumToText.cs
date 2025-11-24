using System;

using Tasks.Common;

namespace Tasks.NumToText
{
    public class NumToText : INumToTextSolution
    {
        public void Run()
        {
            int num;
            string input = Console.ReadLine();
            if (!int.TryParse(input, out num)) {
                return;
            }
            Console.WriteLine(Convert(num));
        }
        
        public string Convert(int num)
        {
            if (num < 1 || num > 99)
            {
                return "Error";
            }

            if (num < 10)
                return GetOnes(num);

            if (num < 20)
            {
                switch (num) {
                    case 10: return "десять";
                    case 11: return "одиннадцать";
                    case 12: return "двенадцать";
                    case 13: return "тринадцать";
                    case 14: return "четырнадцать";
                    case 15: return "пятнадцать";
                    case 16: return "шестнадцать";
                    case 17: return "семнадцать";
                    case 18: return "восемнадцать";
                    case 19: return "девятнадцать";
                }
            }

            int tens = num / 10;
            int ones = num % 10;
        
            string tensStr = "";

            switch (tens)
            {
                case 2: tensStr = "двадцать"; break;
                case 3: tensStr = "тридцать"; break;
                case 4: tensStr = "сорок"; break;
                case 5: tensStr = "пятьдесят"; break;
                case 6: tensStr = "шестьдесят"; break;
                case 7: tensStr = "семьдесят"; break;
                case 8: tensStr = "восемьдесят"; break;
                case 9: tensStr = "девяносто"; break;
            }

            if (ones == 0)
                return tensStr;

            return tensStr + " " + GetOnes(ones);        
        }

        private string GetOnes(int digit)
        {
            switch (digit)
            {
                case 1: return "один";
                case 2: return "два";
                case 3: return "три";
                case 4: return "четыре";
                case 5: return "пять";
                case 6: return "шесть";
                case 7: return "семь";
                case 8: return "восемь";
                case 9: return "девять";
                default: return ""; // Unreachable
            }
        }
    }
}
