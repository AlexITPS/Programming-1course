using System;

namespace Task_2
{
    internal class Program
    {
        private static string DisplayMenu()
        {
            return "\nМеню:\n" +
                   "1. Вычислить уравнение\n" +
                   "2. Закончить";
        }

        private static string ProcessEquation()
        {
            Console.WriteLine("Высчитываем уравнение вида: y = sin(n * x) + cos(k * x) + ln(m * x)");
            Console.WriteLine("Где x = e^z + z, при z > 1 или x = z^2 + 1, при z <= 1.");

            double z = GetInput.GetDouble("Введите z: ");
            double n = GetInput.GetDouble("Введите n: ");
            double k = GetInput.GetDouble("Введите k: ");
            double m = GetInput.GetDouble("Введите m: ");

            var values = Calculation.Calculate(n, k, m, z);
            return $"y = {values.Item1}, Была использована ветка: {values.Item2}.";
        }

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine(DisplayMenu());
                choice = GetInput.GetIntInRange("Введите пункт меню (1-2): ", 1, 2);

                string output;
                switch (choice)
                {
                    case 1:
                        output = ProcessEquation();
                        break;

                    case 2:
                        output = "До свидания!";
                        break;

                    default:
                        output = "Неверный выбор! Введите число от 1 до 2.";
                        break;
                }

                Console.WriteLine(output);

            } while (choice != 2);
        }
    }
}