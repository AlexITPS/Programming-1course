using System;

namespace Task2
{
    // Класс для работы с вводом данных
    public static class InputHandler
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

        public static double GetDouble(string prompt)
        {
            double result;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ошибка ввода! Введите число.");
                Console.Write(prompt);
            }
            return result;
        }
    }

    // Класс для проверки координат
    public static class AreaChecker
    {
        public static string CheckPoint(double x, double y)
        {
            if (IsInsideArea(x, y)) return "Да";
            if (IsOnBorder(x, y)) return "На границе";
            return "Нет";
        }

        private static bool IsInsideArea(double x, double y)
        {
            return y < 23 && x > -y && x < 0;
        }

        private static bool IsOnBorder(double x, double y)
        {
            return
                (y == 23 && x <= 0 && x >= -23) ||
                (x == 0 && y >= 0 && y <= 23) ||
                (y == -x && y <= 23 && x <= 0);
        }
    }

    class Program
    {
        // Отображение меню
        private static void DisplayMenu()
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Продолжить");
            Console.WriteLine("2. Закончить");
        }

        // Основной цикл программы
        static void Main()
        {
            int choice;
            do
            {
                DisplayMenu();
                choice = InputHandler.GetInt("Введите пункт меню (1 или 2): ");

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите координаты точки (x, y):");
                        double x = InputHandler.GetDouble("x: ");
                        double y = InputHandler.GetDouble("y: ");
                        string result = AreaChecker.CheckPoint(x, y);
                        Console.WriteLine(result);
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