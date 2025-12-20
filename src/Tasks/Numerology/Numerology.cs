using System;

using Tasks.Common;

namespace Tasks.Numerology
{
    public class Numerology : INumerologySolution
    {
        private int GetInput()
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int intInput) || intInput < 0)
                {
                    Console.WriteLine($"Введите положительное целое число от 0 до {int.MaxValue}\n");
                }
                else
                {
                    return intInput;
                }
            }
        }

        public void Run()
        {
            int input = GetInput();
            Console.WriteLine(Calculate(input));
        }

        public int Calculate(int num)
        {
            int tempSum = 0;
            int currentNum = num;

            while (true)
            {
                if (currentNum <= 9) return currentNum;

                tempSum += currentNum % 10;
                currentNum /= 10;

                if (currentNum > 9) continue;

                currentNum += tempSum;
                tempSum = 0;
            }
        }
    }
}
