using Tasks.Common;

namespace Tasks.BronzeDigitsCount
{
    public class BronzeDigitsCount : IBronzeDigitsCount
    {
        public int Calculate(int flatCount)
        {
            if (flatCount < 1 || flatCount > 999)
            {
                Console.WriteLine($"Ошибка: Введенное число квартир '{flatCount}' не попадает в диапазон [1;999]");
                return -1;
            }
            int num = 0;
            if (flatCount >= 100)
            {
                num = 90 * 2 + 9 + (flatCount - 99) * 3;
            }
            else if (flatCount >= 10) 
            {
                num = 9 + (flatCount - 9) * 2;
            }
            else
            {
                num = flatCount;
            }
            return num;
        }

        public void Run()
        {
            string input = Console.ReadLine();
            int flatCount;
            try {
                    flatCount = int.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка: Введенная строка не является целым числом.");
                return;
            }

            int num = Calculate(flatCount);
            if (num == -1)
            {
                return;
            }

            Console.WriteLine(num);
        }
    }
}