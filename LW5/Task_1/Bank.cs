using System;
using System.Collections.Generic;
using System.Linq;

public class Bank
{
    private List<Client> clients = new List<Client>();
    private Dictionary<DepositTypeEnum, decimal> interestRates = new Dictionary<DepositTypeEnum, decimal>
    {
        { DepositTypeEnum.Standard, 0.05m },
        { DepositTypeEnum.Premium, 0.07m },
        { DepositTypeEnum.Gold, 0.10m }
    };

    public bool ClientExists(string name)
    {
        foreach (var client in clients)
        {
            if (client.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    public bool AddClient(string name, DepositTypeEnum depositType, decimal initialDeposit)
    {
        if (ClientExists(name)) return false;

        clients.Add(new Client(name, depositType, initialDeposit));
        return true;
    }

    public bool TryAddToClientDeposit(string name, decimal amount, out string message)
    {
        Client client = null;
        foreach (var c in clients)
        {
            if (c.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                client = c;
                break;
            }
        }

        if (client == null)
        {
            message = $"Клиент '{name}' не найден.";
            return false;
        }

        client.AddToDeposit(amount);
        message = null;
        return true;
    }

    public decimal CalculateTotalInterestPayments()
    {
        decimal total = 0m;
        foreach (var client in clients)
        {
            total += client.DepositAmount * interestRates[client.DepositType];
        }
        return total;
    }

    public void PrintClients(Bank bank)
    {
        if (!clients.Any())
        {
            Console.WriteLine("Список клиентов пуст.");
            return;
        }

        foreach (var client in clients)
        {

            decimal rate = bank.interestRates[client.DepositType];

            decimal income = client.DepositAmount * rate;

            Console.WriteLine(
                $"Клиент: {client.Name}\n" +
                $"Депозит: {client.DepositType} ({rate * 100}%)\n" +
                $"Сумма: {client.DepositAmount:N2}\n" +
                $"Доход: {client.DepositAmount} * {rate} = {income:N2}\n" +
                new string('-', 30)
            );
        }
    }
}   