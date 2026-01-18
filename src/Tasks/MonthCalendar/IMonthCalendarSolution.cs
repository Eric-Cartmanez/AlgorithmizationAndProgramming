using Tasks.Common;

namespace Tasks.MonthCalendar
{
    public interface IMonthCalendarSolution : ISolution
    {
        // Метод принимает дату строкой и возвращает готовый календарь строкой
        string GetCalendarVisualization(string date); 
    }
}

