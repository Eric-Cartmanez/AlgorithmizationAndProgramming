using System;

using Tasks.Common;

namespace Tasks.Numerology
{
    public class NumerologyAlt : INumerologySolution
    {
        public void Run()
        {
            if (!int.TryParse(Console.ReadLine(), out int intInput) || intInput < 0)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            Console.WriteLine(Calculate(intInput));
        }

        public int Calculate(int num)
        {
            int newNum = 0;
            while (num > 9)
            {
                newNum += num % 10;
                num /= 10;
                if (num > 9) continue;
                
                newNum += num;
                num = newNum;
                newNum = 0;
            }
            return num;
        }
    }
}
