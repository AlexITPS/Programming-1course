using System;

    public class GetDay
    {
        public static void HandleGetDay(DateService dateService)
        {
            Console.Write("Введите дату в формате дд.мм.гггг (например, 25.12.2023): ");
            string dateInput = Console.ReadLine();

            if (!InputValidator.IsValidStringDate(dateInput, out string errorMessage))
            {
                Console.WriteLine(errorMessage);
                return;
            }

            string result = dateService.GetDay(dateInput);
            Console.WriteLine($"Результат: {result}");
        }

        public static void HandleGetDaysSpan(DateService dateService)
        {
            Console.Write("Введите день (1-31): ");
            string dayInput = Console.ReadLine();
            Console.Write("Введите месяц (1-12): ");
            string monthInput = Console.ReadLine();
            Console.Write("Введите год (например, 2023): ");
            string yearInput = Console.ReadLine();

            // Проверка на пустой ввод
            if (string.IsNullOrWhiteSpace(dayInput) || string.IsNullOrWhiteSpace(monthInput) || string.IsNullOrWhiteSpace(yearInput))
            {
                Console.WriteLine("Ошибка: Все поля должны быть заполнены.");
                return;
            }

            // Преобразование строк в числа
            if (!int.TryParse(dayInput, out int day))
            {
                Console.WriteLine("Ошибка: День должен быть корректным числом.");
                return;
            }
            if (!int.TryParse(monthInput, out int month))
            {
                Console.WriteLine("Ошибка: Месяц должен быть корректным числом.");
                return;
            }
            if (!int.TryParse(yearInput, out int year))
            {
                Console.WriteLine("Ошибка: Год должен быть корректным числом.");
                return;
            }

            // Передаем int значения в DateService
            var (days, isFuture, dateError) = dateService.GetDaysSpan(day, month, year);
            if (!string.IsNullOrEmpty(dateError))
            {
                Console.WriteLine(dateError);
            }
            else
            {
                string message = isFuture ? "осталось до" : "прошло с";
                Console.WriteLine($"Количество дней: {days} ({message} указанной даты).");
            }
        }
    }
