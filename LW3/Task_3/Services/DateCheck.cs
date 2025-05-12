using System;

public static class InputValidator
{
    public static bool IsValidStringDate(string input, out string errorMessage)
    {
        errorMessage = string.Empty;
        if (string.IsNullOrWhiteSpace(input))
        {
            errorMessage = "Ошибка: Ввод не может быть пустым.";
            return false;
        }
        return true;
    }

    public static bool IsValidChoice(string input, out int choice, out string errorMessage)
    {
        choice = 0;
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(input))
        {
            errorMessage = "Ошибка: Ввод не может быть пустым.";
            return false;
        }

        if (!int.TryParse(input, out choice))
        {
            errorMessage = "Ошибка: Введите число.";
            return false;
        }

        if (choice < 1 || choice > 3)
        {
            errorMessage = "Ошибка: Введите число от 1 до 3.";
            return false;
        }

        return true;
    }
}