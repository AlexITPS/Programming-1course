using System;

namespace _453504_Ярцев
{
    class Program
    {
        static void Main()
        {
            int number_1, number_2, number_3;
            Console.WriteLine("Введите делимое: ");
            number_1 = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Введите делитель: ");
            number_2 = int.Parse(Console.ReadLine() ?? "0");

            // Проверка на деление на ноль
            if (number_2 == 0)
            {
                Console.WriteLine("Деление на ноль недопустимо.");
                return; // Завершение программы в случае, при условии b == 0 
            }

            number_3 = Divide(number_1, number_2);
            Console.WriteLine("Частное: ");
            Console.WriteLine(number_3);
        }

        public static int Divide(int x, int y)
        {
            return x / y;
        }
    }
}