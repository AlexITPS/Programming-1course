namespace Shop
{
    public class Clothing : Product
    {
        private string size;
        private string material;

        public Clothing(string name, decimal price, int stock, string size, string material)
            : base(name, price, stock) // Вызов конструктора базового класса
        {
            this.size = size;
            this.material = material;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Clothing: {Name}, Size: {size}, Material: {material}, Price: {Price}, Stock: {Stock}");
        }
        // UpdateStock не переопределяется, используется базовая реализация
    }
}