using System;

namespace Shop
{
    class Program
    {
        static void Main()
        {
            Electronics phone = new Electronics("Phone", 500m, 10, "BrandX", 12);
            Clothing shirt = new Clothing("Shirt", 30m, 20, "L", "Cotton");
            Food apple = new Food("Apple", 1m, 100, DateTime.Now);

            // Демонстрация методов
            Console.WriteLine("=== Display Info ===");
            phone.DisplayInfo();
            shirt.DisplayInfo();
            apple.DisplayInfo();

            Console.WriteLine("\n=== Update Stock ===");
            phone.UpdateStock(5);  // Переопределенный метод
            phone.UpdateStock(3, "New shipment"); // Перегруженный метод
            shirt.UpdateStock(4);  // Базовый метод

            Console.WriteLine("\n=== Change Price ===");
            phone.ChangePrice(550m); // Базовый метод
            shirt.ChangePrice(35m);  // Базовый метод
            apple.ChangePrice(1.5m); // Скрытый метод с вызовом базового
        }
    }
}