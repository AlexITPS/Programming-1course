using System;

public class Program
{
    static void Main()
    {
        DateService dateService = new DateService();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Узнать день недели по дате");
            Console.WriteLine("2. Узнать количество дней до даты");
            Console.WriteLine("3. Выход");

            Console.Write("Ваш выбор (1-3): ");
            string choiceInput = Console.ReadLine();

            if (!InputValidator.IsValidChoice(choiceInput, out int choice, out string errorMessage))
            {
                Console.WriteLine(errorMessage);
                continue;
            }

            switch (choice)
            {
                case 1:
                    GetDay.HandleGetDay(dateService);
                    break;

                case 2:
                    GetDay.HandleGetDaysSpan(dateService);
                    break;

                case 3:
                    running = false;
                    Console.WriteLine("Программа завершена.");
                    break;
            }
        }
    }
}