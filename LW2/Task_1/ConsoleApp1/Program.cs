using System;

namespace ConsoleApp1
{
    public static class GetInput
    {
        public static int GetInt(string prompt)
        {
            int result;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число.");
                Console.Write(prompt);
            }
            return result;
        }

        public static bool IsTwoDigitNumber(int number)
        {
            return (number >= 10 && number < 100) || (number <= -10 && number > -100);
        }
    }

    public static class Calculator
    {
        public static int CalculateSumOfDigits(int number)
        {
            return Math.Abs(number / 10) + Math.Abs(number % 10);
        }

        public static string CheckDivision(int number, int divisor)
        {
            if (divisor == 0)
            {
                return "Ошибка: Деление на ноль невозможно.";
            }

            int sum = CalculateSumOfDigits(number);
            return sum % divisor == 0
                ? $"Сумма цифр числа {number} кратна числу {divisor}."
                : $"Сумма цифр числа {number} не кратна числу {divisor}.";
        }
    }

    class Program
    {
        private static (int A, int number) GetNumbers()
        {
            int A = GetInput.GetInt("Введите значение числа A: ");

            int number;
            do
            {
                number = GetInput.GetInt("Введите двухзначное число: ");
            } while (!GetInput.IsTwoDigitNumber(number));

            return (A, number);
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Продолжить программу.");
            Console.WriteLine("2. Завершить программу");
        }

        static void Main()
        {
            int choice;
            do
            {
                DisplayMenu();
                choice = GetInput.GetInt("Введите пункт меню (1 или 2): ");

                switch (choice)
                {
                    case 1:
                        var (A, number) = GetNumbers();
                        Console.WriteLine(Calculator.CheckDivision(number, A));
                        break;

                    case 2:
                        Console.WriteLine("До свидания!");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор! Введите 1 или 2.");
                        break;
                }
            } while (choice != 2);
        }
    }
}