namespace BankSystem;

// Интерфейс для стратегии начисления бонусов
public interface IDepositBonusStrategy
{
    decimal CalculateBonus(decimal initialDeposit);
}