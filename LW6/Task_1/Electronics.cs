namespace Shop
{
    public class Electronics : Product
    {
        private string brand;
        private int warranty;

        public Electronics(string name, decimal price, int stock, string brand, int warranty)
            : base(name, price, stock) // Вызов конструктора базового класса
        {
            this.brand = brand;
            this.warranty = warranty;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Electronics: {Name}, Brand: {brand}, Price: {Price}, Stock: {Stock}, Warranty: {warranty} months");
        }

        public override void UpdateStock(int quantity)
        {
            Stock += quantity;
            Console.WriteLine($"{Name} (Electronics) stock updated to {Stock}");
        }

        // Перегрузка метода UpdateStock
        public void UpdateStock(int quantity, string reason)
        {
            Stock += quantity;
            Console.WriteLine($"{Name} (Electronics) stock updated to {Stock} due to {reason}");
        }
    }
}