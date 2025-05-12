namespace BankSystem;

public class StandardBonusStrategy : IDepositBonusStrategy
{
    public decimal CalculateBonus(decimal initialDeposit)
    {
        return 0m; // Без бонуса
    }
}