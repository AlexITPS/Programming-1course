using System;
using System.Collections.Generic;

public class Bank
{
    private static Bank instance;
    private static string _name;
    private List<Deposit> deposits;

    private Bank()
    {
        if (string.IsNullOrWhiteSpace(_name))
            throw new InvalidOperationException("Сначала инициализируйте имя банка!");

        deposits = new List<Deposit>();
    }

    public static void Initialize(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название банка не может быть пустым.");

        _name = name;
    }

    public static Bank GetInstance()
    {
        if (instance == null)
        {
            if (string.IsNullOrWhiteSpace(_name))
                throw new InvalidOperationException("Сначала инициализируйте имя банка!");

            instance = new Bank();
        }
        return instance;
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Название банка не может быть пустым.");
            _name = value;
        }
    }

    public void AddDeposit(Deposit deposit)
    {
        deposits.Add(deposit);
    }

    public decimal CalculateTotalInterest(out List<(decimal Rate, decimal Interest)> details)
    {
        decimal total = 0;
        details = new List<(decimal Rate, decimal Interest)>();

        for (int i = 0; i < deposits.Count; i++)
        {
            decimal interest = deposits[i].CalculateInterest();
            total += interest;
            details.Add((deposits[i].InterestRate, interest));
        }

        return total;
    }

    public int NumberOfDeposits
    {
        get { return deposits.Count; }
    }
}