namespace BankSystem;

public class Client : IClient
{
    public string Name { get; }
    public DepositTypeEnum DepositType { get; }
    public decimal DepositAmount { get; private set; }

    public Client(string name, DepositTypeEnum depositType, decimal initialDeposit, IDepositBonusStrategy bonusStrategy)
    {
        Name = name;
        DepositType = depositType;
        DepositAmount = initialDeposit + bonusStrategy.CalculateBonus(initialDeposit); // Применяем стратегию
    }

    public void AddToDeposit(decimal amount)
    {
        if (amount > 0)
            DepositAmount += amount;
    }
}