namespace ProductManagement.Models
{
    public class Product
    {
        public static int count = 1;
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }

        public Product()
        {
            Id = count++;
        }

        public void InputInfo()
        {
            Name = Utils.GetStringInput("Enter product name: ", "Name cannot be empty.");
            Price = Utils.GetDoubleInput("Enter product price: ", "Price must be a positive number.");
            QuantityInStock = Utils.GetIntInput("Enter quantity in stock: ", "Quantity must be a positive number.");
        }

        public void OutputInfo()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine($"| Product ID: {Id}");
            Console.WriteLine($"| Product Name: {Name}");
            Console.WriteLine($"| Price: {Price}");
            Console.WriteLine($"| Quantity in Stock: {QuantityInStock}");
            Console.WriteLine("==============================================");
        }
    }
}
