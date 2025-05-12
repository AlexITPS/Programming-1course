using System;

namespace Task_1
{
    public static class InputHandler
    {
        public static uint GetUInt()
        {
            uint result;
            while (!uint.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ошибка ввода! Введите положительное целое число.");
            }
            return result;
        }
    }
}