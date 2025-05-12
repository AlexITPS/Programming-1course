public class Deposit
{
    private static decimal depositAmount; // Размер вклада (общий для всех)
    private decimal interestRate; // Процентная ставка

    public Deposit(decimal interestRate)
    {
        this.interestRate = interestRate;
    }

    public decimal InterestRate
    {
        get { return interestRate; }
        set { interestRate = value; }
    }

    public static decimal DepositAmount
    {
        get { return depositAmount; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Размер вклада не может быть отрицательным.");
            depositAmount = value;
        }
    }

    public static void IncreaseDepositAmount(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Сумма увеличения не может быть отрицательной.");
        DepositAmount = depositAmount + amount;
    }

    public static void DecreaseDepositAmount(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Сумма уменьшения не может быть отрицательной.");
        DepositAmount = depositAmount - amount;
    }

    public decimal CalculateInterest()
    {
        return depositAmount * (interestRate / 100);
    }
}