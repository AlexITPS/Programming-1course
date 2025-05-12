using System;
using PolynomialClass;

namespace PolynomialDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("=== Создание полиномов ===");
                Polynomial p1 = new Polynomial(2, 3, 4);
                Polynomial p2 = new Polynomial(1, 1, 1);
                Polynomial p3 = new Polynomial();
                Console.WriteLine($"p1: {p1}");
                Console.WriteLine($"p2: {p2}");
                Console.WriteLine($"p3: {p3}");

                Console.WriteLine("\n=== Свойства и индексатор ===");
                p1.A = 6;
                Console.WriteLine($"p1 после p1.A = 6: {p1}");
                p1[1] = 8;
                Console.WriteLine($"p1 после p1[1] = 8: {p1}");

                Console.WriteLine("\n=== Математические операции ===");
                Polynomial sum = p1 + p2;
                Console.WriteLine($"p1 + p2: {sum}");
                Polynomial diff = p1 - p2;
                Console.WriteLine($"p1 - p2: {diff}");
                Polynomial mult = p1 * 2;
                Console.WriteLine($"p1 * 2: {mult}");
                Polynomial div = p1 / 2;
                Console.WriteLine($"p1 / 2: {div}");

                Console.WriteLine("\n=== Инкремент и декремент ===");
                p3 = ++p3;
                Console.WriteLine($"p3 после ++: {p3}");
                p3 = --p3;
                Console.WriteLine($"p3 после --: {p3}");

                Console.WriteLine("\n=== Сравнение ===");
                Console.WriteLine($"p1 == p2: {p1 == p2}");
                Console.WriteLine($"p1 != p2: {p1 != p2}");

                Console.WriteLine("\n=== True/False ===");
                Console.WriteLine($"p1 is true: {(p1 ? "Yes" : "No")}");
                Console.WriteLine($"p3 is true: {(p3 ? "Yes" : "No")}");

                Console.WriteLine("\n=== Преобразование типов ===");
                int value = (int)p1;
                Console.WriteLine($"p1 -> int: {value}");
                Polynomial fromInt = (Polynomial)10;
                Console.WriteLine($"10 -> Polynomial: {fromInt}");

                Console.WriteLine("\n=== Обработка ошибок ===");
                try
                {
                    Polynomial error = p1 / 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                try
                {
                    Polynomial test = p1 / 3; // 6,8,4 не делится на 3 без остатка
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка деления: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}