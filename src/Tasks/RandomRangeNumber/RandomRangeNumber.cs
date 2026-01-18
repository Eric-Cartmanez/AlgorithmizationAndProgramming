using System;
using System.Security.Cryptography.X509Certificates;
using Tasks.Common;

namespace Tasks.RandomRangeNumber
{
    public class RandomRangeNumber : IRandomRangeNumberSolution
    {
        public void Run()
        {
            uint min = 1;
            uint max = 100;

            if (AskUser())
               GetMinMaxValues(ref min, ref max);

            if (!GetDivisor(max, out uint d)) 
                return;

            try
            {
                uint number = GetNumber(d, min, max);
                Console.WriteLine(number);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Метод для получения случайного числа
        // Возвращает случайное число из диапазона [min, max], кратное d
        public uint GetNumber(uint d, uint min = 1, uint max = 100)
        {
            uint minDivisible = min % d == 0 ? min : min + (d - (min % d));
            uint maxDivisible = max - (max % d);

            if (minDivisible > maxDivisible)
               throw new InvalidOperationException($"В диапазоне [{min}, {max}] нет чисел, делящихся на {d}.");

            long numbersCount = (long)(maxDivisible - minDivisible) / d + 1;
            long randomIndex = Random.Shared.NextInt64(numbersCount);

            return (uint)(minDivisible + (randomIndex * d));
        }

        private static bool AskUser()
        {
            Console.WriteLine("Хотите изменить минимальное и максимальное значение? y - да");
            return char.ToLower(Console.ReadKey(true).KeyChar) == 'y';
        }

        // Запрашивает у пользователя границы диапазона и проверяет их корректность
        private static void GetMinMaxValues(ref uint min, ref uint max)
        {
            Console.WriteLine("Введите минимальное значение");
            string? input = Console.ReadLine();
            if (!uint.TryParse(input, out uint inputMin))
            {
                Console.WriteLine("Неккоректный ввод. Будут использованы значения по умолчанию");
                return;
            }
            Console.WriteLine("Введите максимальное значение");
            input = Console.ReadLine();
            if (!uint.TryParse(input, out uint inputMax))
            {
                Console.WriteLine("Неккоректный ввод. Будут использованы значения по умолчанию");
                return;
            }
            if (inputMin >= inputMax)
            {
                Console.WriteLine("Неккоректный ввод. Минимальное число должно быть меньше чем максмальное");
                return;
            }
            min = inputMin;
            max = inputMax;
        }

        // Запрашивает у пользователя делитель d и проверяет его корректность
        private static bool GetDivisor(uint maxBoundary, out uint d)
        {
            Console.WriteLine("Введите число делитель d:");
            string? input = Console.ReadLine();
            if (!uint.TryParse(input, out d))
            {
                Console.WriteLine("Некорректный ввод. Требуется целое положительное число.");
                return false;
            }
            if (d == 0)
            {
                Console.WriteLine("Некорректный ввод. Число d не должно быть равно 0.");
                return false;
            }
            if (d > maxBoundary)
            {
                Console.WriteLine("Некорректный ввод. Число d должно быть меньше или равно максимальному числу диапазона.");
                return false;
            }
            return true;
        }
    }
}
