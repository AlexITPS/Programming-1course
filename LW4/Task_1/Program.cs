using System;

class Program
{
    static void Main(string[] args)
    {

        string bankName = InputValidator.GetValidString("Введите наименование банка: ");
        Bank.Initialize(bankName);
        Bank bank = Bank.GetInstance();

        decimal initialDeposit = InputValidator.GetValidDecimal("Введите размер вклада: ");
        Deposit.DepositAmount = initialDeposit;

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить вклад");
            Console.WriteLine("2. Увеличить размер вклада");
            Console.WriteLine("3. Уменьшить размер вклада");
            Console.WriteLine("4. Вывести информацию о банке");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Ошибка: Выбор не может быть пустым.");
                continue;
            }

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    decimal rate = InputValidator.GetValidDecimal("Введите процентную ставку: ");
                    Deposit deposit = new Deposit(rate);
                    bank.AddDeposit(deposit);
                    Console.WriteLine("Вклад добавлен.");
                    break;

                case "2":
                    decimal increaseAmount = InputValidator.GetValidDecimal("Введите сумму для увеличения: ");
                    try
                    {
                        Deposit.IncreaseDepositAmount(increaseAmount);
                        Console.WriteLine("Размер вклада увеличен.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    break;

                case "3":
                    decimal decreaseAmount = InputValidator.GetValidDecimal("Введите сумму для уменьшения: ");
                    try
                    {
                        Deposit.DecreaseDepositAmount(decreaseAmount);
                        Console.WriteLine("Размер вклада уменьшен.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    break;

                case "4":
                    Console.WriteLine($"Наименование банка: {bank.Name}");
                    Console.WriteLine($"Число вкладов: {bank.NumberOfDeposits}");
                    Console.WriteLine($"Текущий размер вклада: {Deposit.DepositAmount}");

                    var totalInterest = bank.CalculateTotalInterest(out var details);
                    Console.WriteLine("Детали выплат по процентам:");
                    for (int i = 0; i < details.Count; i++)
                    {
                        Console.WriteLine($"Вклад {i + 1}: Ставка {details[i].Rate}%, Проценты {details[i].Interest}");
                    }
                    Console.WriteLine($"Общая выплата по процентам: {totalInterest}");
                    break;

                case "5":
                    Console.WriteLine("Выход из программы.");
                    return;

                default:
                    Console.WriteLine("Ошибка: Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}