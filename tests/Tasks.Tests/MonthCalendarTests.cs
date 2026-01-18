using Xunit;
using Tasks.MonthCalendar;

namespace Tasks.Tests
{
    public class MonthCalendarTests
    {
        private readonly IMonthCalendarSolution _solution;

        public MonthCalendarTests()
        {
            _solution = new Tasks.MonthCalendar.MonthCalendar();
        }

        private string Normalize(string input) => 
            input.Replace("\r\n", "\n").Replace("\r", "\n").Trim();

        [Theory]
        // Январь 2025.
        // Обрати внимание на смену формата после числа 9.
        // 10 11 12 теперь прижаты влево внутри своих колонок.
        [InlineData("14.01.2025", """
            Дата: 14 января 2025 г.

            Календарь на месяц
             M  T  W  T  F  S  S
                   1  2  3  4  5 
             6  7  8  9 10 11 12 
            13 14 15 16 17 18 19 
            20 21 22 23 24 25 26 
            27 28 29 30 31 
            """)]
        // Февраль 2021.
        // Проверяем начало строки: `15` стоит ровно под ` 8`.
        // ` 8` (пробел-8-пробел). `15` (1-5-пробел). 
        // Единица числа 15 визуально совпадает с пробелом перед восьмеркой.
        [InlineData("15.02.2021", """
            Дата: 15 февраля 2021 г.

            Календарь на месяц
             M  T  W  T  F  S  S
             1  2  3  4  5  6  7 
             8  9 10 11 12 13 14 
            15 16 17 18 19 20 21 
            22 23 24 25 26 27 28 
            """)]
        // Октябрь 2023.
        [InlineData("01.10.2023", """
            Дата: 1 октября 2023 г.

            Календарь на месяц
             M  T  W  T  F  S  S
                               1 
             2  3  4  5  6  7  8 
             9 10 11 12 13 14 15 
            16 17 18 19 20 21 22 
            23 24 25 26 27 28 29 
            30 31 
            """)]
        public void ValidDates_ReturnCorrectGrid(string input, string expected)
        {
            var result = _solution.GetCalendarVisualization(input);
            Assert.Equal(Normalize(expected), Normalize(result));
        }

        [Theory]
        [InlineData("invalid")]
        [InlineData("32.01.2023")] 
        [InlineData("01.13.2023")]
        [InlineData("2023.01.01")] 
        public void InvalidDates_ReturnErrorMessage(string input)
        {
            var result = _solution.GetCalendarVisualization(input);
            Assert.Contains("Некорректная дата", result);
        }
    }
}
