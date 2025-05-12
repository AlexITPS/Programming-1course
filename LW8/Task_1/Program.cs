using System;

namespace BankSystem;

class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("\n[Банковская система]");
            Console.WriteLine("1. Добавить клиента");
            Console.WriteLine("2. Пополнить вклад");
            Console.WriteLine("3. Список клиентов");
            Console.WriteLine("4. Общая сумма вкладов");
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
                    bank.PrintClients();
                    break;
                case "4":
                    Console.WriteLine($"Общая сумма вкладов: {bank.CalculateTotalDeposits():N2}");
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