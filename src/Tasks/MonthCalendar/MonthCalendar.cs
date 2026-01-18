using System;
using System.Globalization;
using System.Text;
using Tasks.Common;

namespace Tasks.MonthCalendar
{
    public class MonthCalendar : IMonthCalendarSolution
    {
        private static readonly CultureInfo RuCulture = CultureInfo.GetCultureInfo("ru-RU");

        public void Run()
        {
            Console.WriteLine("Введите дату (DD.MM.YYYY):");
            string? input = Console.ReadLine();
            Console.WriteLine();
            Console.Write(GetCalendarVisualization(input!));
        }

        public string GetCalendarVisualization(string dateInput)
        {
            if (!DateTime.TryParseExact(dateInput, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return "Некорректная дата" + Environment.NewLine;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Дата: {date.ToString("d MMMM yyyy 'г.'", RuCulture)}");
            sb.AppendLine();
            sb.AppendLine("Календарь на месяц");
            sb.AppendLine(" M  T  W  T  F  S  S");

            DateTime firstDay = new(date.Year, date.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            
            int currentDayOfWeekIndex = (int)firstDay.DayOfWeek == 0 ? 6 : (int)firstDay.DayOfWeek - 1;

            sb.Append(new string(' ', currentDayOfWeekIndex * 3));

            for (int day = 1; day <= daysInMonth; day++)
            {
                if (day < 10)
                {
                    sb.Append($" {day} ");
                }
                else
                {
                    sb.Append($"{day} ");
                }

                currentDayOfWeekIndex++;

                if (currentDayOfWeekIndex == 7)
                {
                    sb.AppendLine();
                    currentDayOfWeekIndex = 0;
                }
            }
            
            if (currentDayOfWeekIndex != 0)
            {
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
