public class Client
{
    public string Name { get; }
    public DepositTypeEnum DepositType { get; }
    public decimal DepositAmount { get; private set; }

    public Client(string name, DepositTypeEnum depositType, decimal initialDeposit)
    {
        Name = name;
        DepositType = depositType;
        DepositAmount = initialDeposit;
    }

    public void AddToDeposit(decimal amount) => DepositAmount += amount;
}