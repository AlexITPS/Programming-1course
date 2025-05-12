namespace Shop
{
    internal abstract class Product
    {
        private string name;
        private decimal price;
        private int stock;

        protected Product(string name, decimal price, int stock)
        {
            this.name = name;
            this.price = price;
            this.stock = stock;
        }

        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public int Stock { get => stock; set => stock = value; }

        public abstract void DisplayInfo(); // Абстрактный метод

        public virtual void UpdateStock(int quantity) // Виртуальный метод
        {
            Stock += quantity;
            Console.WriteLine($"{Name} stock updated to {Stock}");
        }

        public void ChangePrice(decimal newPrice) // Метод с реализацией
        {
            Price = newPrice;
            Console.WriteLine($"{Name} price changed to {Price}");
        }
    }
}