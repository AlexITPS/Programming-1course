using System;

namespace Task_2
{
    public static class GetInput
    {
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

        public static int GetIntInRange(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                    return result;
                Console.WriteLine($"Ошибка! Введите число от {min} до {max}.");
            }
        }
    }
}