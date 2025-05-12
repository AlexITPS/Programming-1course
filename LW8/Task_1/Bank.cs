using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem;

public class Bank
{
    private readonly List<IClient> clients = new List<IClient>();
    private readonly Dictionary<DepositTypeEnum, decimal> interestRates = new Dictionary<DepositTypeEnum, decimal>
    {
        { DepositTypeEnum.Standard, 0.05m },
        { DepositTypeEnum.Premium, 0.07m },
        { DepositTypeEnum.Gold, 0.10m }
    };

    private readonly Dictionary<DepositTypeEnum, IDepositBonusStrategy> bonusStrategies = new Dictionary<DepositTypeEnum, IDepositBonusStrategy>
    {
        { DepositTypeEnum.Standard, new StandardBonusStrategy() },
        { DepositTypeEnum.Premium, new PremiumBonusStrategy() },
        { DepositTypeEnum.Gold, new GoldBonusStrategy() }
    };

    public bool ClientExists(string name)
    {
        return clients.Any(client => client.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public bool HasClients()
    {
        return clients.Any();
    }

    public bool AddClient(string name, DepositTypeEnum depositType, decimal initialDeposit)
    {
        if (ClientExists(name) || initialDeposit <= 0)
            return false;

        var client = new Client(name, depositType, initialDeposit, bonusStrategies[depositType]);
        clients.Add(client);
        return true;
    }

    public bool TryAddToClientDeposit(string name, decimal amount, out string message)
    {
        IClient client = clients.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (client == null)
        {
            message = $"Клиент '{name}' не найден.";
            return false;
        }

        if (amount <= 0)
        {
            message = "Сумма пополнения должна быть положительной.";
            return false;
        }

        client.AddToDeposit(amount);
        message = null;
        return true;
    }

    public decimal CalculateTotalDeposits()
    {
        return clients.Sum(client => client.DepositAmount);
    }

    public void PrintClients()
    {
        if (!clients.Any())
        {
            Console.WriteLine("Список клиентов пуст.");
            return;
        }

        foreach (IClient client in clients)
        {
            decimal rate = interestRates[client.DepositType];
            decimal income = client.DepositAmount * rate;

            Console.WriteLine(
                $"Клиент: {client.Name}\n" +
                $"Депозит: {client.DepositType} ({rate * 100}%)\n" +
                $"Сумма: {client.DepositAmount:N2}\n" +
                $"Доход: {income:N2}\n" +
                new string('-', 30)
            );
        }
    }
}