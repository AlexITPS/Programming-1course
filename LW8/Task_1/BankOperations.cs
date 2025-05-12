using System;

namespace BankSystem;

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
        Console.WriteLine("1. Standard (5%) - (Нету бонусов)");
        Console.WriteLine("2. Premium (7%) - (Бонусами будет начислено 500)");
        Console.WriteLine("3. Gold (10%) - (Бонусами будет начислено 1000)");
        Console.Write("Выберите опцию: ");

        if (!int.TryParse(Console.ReadLine()?.Trim(), out int type) || type < 1 || type > 3)
        {
            Console.WriteLine("Неверный выбор типа вклада.");
            return;
        }

        DepositTypeEnum depositType = (DepositTypeEnum)(type - 1);

        Console.Write("Введите начальную сумму вклада: ");
        if (!decimal.TryParse(Console.ReadLine()?.Trim(), out decimal initialDeposit) || initialDeposit <= 0)
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
        if (!bank.HasClients())
        {
            Console.WriteLine("Список клиентов пуст.");
            return;
        }

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
        if (!decimal.TryParse(Console.ReadLine()?.Trim(), out decimal amount) || amount <= 0)
        {
            Console.WriteLine("Неверная сумма для пополнения.");
            return;
        }

        Console.WriteLine(bank.TryAddToClientDeposit(name, amount, out string message)
            ? $"Счёт '{name}' успешно пополнен на {amount}."
            : message);
    }
}