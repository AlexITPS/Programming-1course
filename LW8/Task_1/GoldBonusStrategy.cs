namespace BankSystem;

public class GoldBonusStrategy : IDepositBonusStrategy
{
    public decimal CalculateBonus(decimal initialDeposit)
    {
        return 1000m; // Фиксированный бонус 1000
    }
}