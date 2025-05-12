using System;

namespace Task_1
{
    internal class Program
    {
        private static string DisplayMenu()
        {
            return "\nМеню:\n" +
                   "1. Вычислить квадрат числа\n" +
                   "2. Вычислить сумму квадратов чисел 2, 3 и 4\n" +
                   "3. Закончить";
        }

        private static string ProcessSquare()
        {
            uint n = InputHandler.GetUInt();
            uint result = Exponentiation.Square(n);
            return $"{n} * {n} = {result}";
        }

        private static string ProcessSumOfSquares()
        {
            uint result = Exponentiation.Square(2) + Exponentiation.Square(3) + Exponentiation.Square(4);
            return $"2^2 + 3^2 + 4^2 = {result}";
        }


        static void Main()
        {
            uint choice;
            do
            {
                Console.WriteLine(DisplayMenu());
                choice = InputHandler.GetUInt();

                string output;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите число n: ");
                        output = ProcessSquare();
                        break;

                    case 2:
                        output = ProcessSumOfSquares();
                        break;

                    case 3:
                        output = "До свидания!";
                        break;

                    default:
                        output = "Неверный выбор! Введите число от 1 до 3.";
                        break;
                }

                Console.WriteLine(output);

            } while (choice != 3);
        }
    }
}