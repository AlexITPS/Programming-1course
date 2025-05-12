using System;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("\n[Банковская система]");
            Console.WriteLine("1. Добавить клиента");
            Console.WriteLine("2. Пополнить вклад");
            Console.WriteLine("3. Список клиентов");
            Console.WriteLine("4. Расчёт выплат по процентам");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    BankOperations.AddClient(bank);
                    break;
                case "2":
                    BankOperations.AddToDeposit(bank);
                    break;
                case "3":
                    bank.PrintClients(bank);
                    break;
                case "4":
                    Console.WriteLine($"Общая сумма выплат: {bank.CalculateTotalInterestPayments()}");
                    break;
                case "5":
                    Console.WriteLine("Работа завершена.");
                    return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }
}