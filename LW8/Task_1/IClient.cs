namespace BankSystem;

// Интерфейс клиента
public interface IClient
{
    string Name { get; }
    DepositTypeEnum DepositType { get; }
    decimal DepositAmount { get; }
    void AddToDeposit(decimal amount);
}