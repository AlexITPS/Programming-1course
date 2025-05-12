namespace BankSystem;

public class PremiumBonusStrategy : IDepositBonusStrategy
{
    public decimal CalculateBonus(decimal initialDeposit)
    {
        return 500m; // Фиксированный бонус 500
    }
}