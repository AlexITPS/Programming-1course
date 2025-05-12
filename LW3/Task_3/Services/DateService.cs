using System;
using System.Globalization;

public class DateService
{

    public string GetDay(string date)
    {
        if (DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            // Массив с названиями дней недели на русском
            string[] daysOfWeek = { "Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };

            // Получаем индекс дня недели (0 - воскресенье, 1 - понедельник и т.д.)
            int dayIndex = (int)parsedDate.DayOfWeek;

            return daysOfWeek[dayIndex];
        }
        else
        {
            return "Неверная дата";
        }
    }

    public (int days, bool isFuture, string errorMessage) GetDaysSpan(int day, int month, int year)
    {
        if (day < 1 || day > 31)
        {
            return (0, false, "Ошибка: День должен быть в диапазоне 1-31.");
        }
        if (month < 1 || month > 12)
        {
            return (0, false, "Ошибка: Месяц должен быть в диапазоне 1-12.");
        }
        if (year < 1)
        {
            return (0, false, "Ошибка: Год должен быть больше 0.");
        }

        try
        {
            DateTime targetDate = new DateTime(year, month, day);
            TimeSpan span = targetDate - DateTime.Today;
            int days = Math.Abs(span.Days);
            bool isFuture = span.Days >= 0;
            return (days, isFuture, string.Empty);
        }
        catch (ArgumentOutOfRangeException)
        {
            return (0, false, "Ошибка: Введена некорректная дата (например, 29 февраля в невисокосный год).");
        }
    }
}