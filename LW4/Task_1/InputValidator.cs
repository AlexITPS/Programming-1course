using System;

public static class InputValidator
{
    public static string GetValidString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input;
            Console.WriteLine("Ошибка: Ввод не может быть пустым.");
        }
    }

    public static decimal GetValidDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal result) && result >= 0)
                return result;
            Console.WriteLine("Ошибка: Введите неотрицательное число.");
        }
    }
}