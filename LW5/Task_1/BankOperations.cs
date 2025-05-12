using System;

public static class BankOperations
{
    public static void AddClient(Bank bank)
    {
        Console.Write("Введите имя клиента: ");
        string name = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Имя клиента не может быть пустым.");
            return;
        }

        if (bank.ClientExists(name))
        {
            Console.WriteLine($"Клиент '{name}' уже существует.");
            return;
        }

        Console.WriteLine("Выберите тип вклада:");
        Console.WriteLine("1. Standard (5%)");
        Console.WriteLine("2. Premium (7%)");
        Console.WriteLine("3. Gold (10%)");
        Console.Write("Выберите опцию: ");
        string typeChoice = Console.ReadLine()?.Trim();

        if (!int.TryParse(typeChoice, out int type) || type < 1 || type > 3)
        {
            Console.WriteLine("Неверный выбор типа вклада.");
            return;
        }

        DepositTypeEnum depositType = (DepositTypeEnum)(type - 1);
        AddInitialDeposit(bank, name, depositType);
    }

    private static void AddInitialDeposit(Bank bank, string name, DepositTypeEnum depositType)
    {
        Console.Write("Введите начальную сумму вклада: ");
        string depositInput = Console.ReadLine()?.Trim();

        if (!decimal.TryParse(depositInput, out decimal initialDeposit) || initialDeposit <= 0)
        {
            Console.WriteLine("Неверная сумма вклада.");
            return;
        }

        Console.WriteLine(bank.AddClient(name, depositType, initialDeposit)
            ? "Клиент успешно добавлен."
            : $"Ошибка при добавлении клиента '{name}'");
    }

    public static void AddToDeposit(Bank bank)
    {
        Console.Write("Введите имя клиента: ");
        string name = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Имя клиента не может быть пустым.");
            return;
        }

        if (!bank.ClientExists(name))
        {
            Console.WriteLine($"Клиент '{name}' не найден.");
            return;
        }

        Console.Write("Введите сумму для пополнения: ");
        string amountInput = Console.ReadLine()?.Trim();

        if (!decimal.TryParse(amountInput, out decimal amount) || amount <= 0)
        {
            Console.WriteLine("Неверная сумма для пополнения.");
            return;
        }

        Console.WriteLine(bank.TryAddToClientDeposit(name, amount, out string message)
            ? $"Счёт '{name}' успешно пополнен на {amount}."
            : message);
    }
}