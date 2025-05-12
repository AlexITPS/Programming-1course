namespace Shop
{
    public sealed class Food : Product // Закрытый для наследования
    {
        private DateTime expirationDate;

        public Food(string name, decimal price, int stock, DateTime expirationDate)
            : base(name, price, stock) // Вызов конструктора базового класса
        {
            this.expirationDate = expirationDate;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Food: {Name}, Price: {Price}, Expires: {expirationDate:dd-MM-yyyy}, Stock: {Stock}");
        }

        public new void ChangePrice(decimal newPrice) // Скрытие метода родителя
        {
            Console.WriteLine($"Food price change: {Name} to {newPrice}");
            base.ChangePrice(newPrice); // Вызов метода родителя
        }
    }
}