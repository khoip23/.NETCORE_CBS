using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Menu menu = new Menu();
        menu.LoadFromFile();
        int choice;
        do
        {
            menu.ShowMenuFunction();
            choice = Utils.GetIntInput("Choose an option: ", "Invalid input, please enter a valid number.");
            switch (choice)
            {
                case 1:
                    menu.AddProduct();
                    break;
                case 2:
                    menu.SearchProductByName();
                    break;
                case 3:
                    menu.UpdateProductPrice();
                    break;
                case 4:
                    menu.UpdateProductQuantityInStock();
                    break;
                case 5:
                    menu.CalculateTotalInventoryValue();
                    break;
                case 6:
                    menu.DeleteProduct();
                    break;
                case 7:
                    menu.ShowAllProducts();
                    break;
                case 8:
                    menu.ShowProductsByPriceAscending();
                    break;
                case 9:
                    menu.ShowProductsByNameAscending();
                    break;
                case 10:
                    menu.SortProductsByLastWordInName();
                    break;
                case 11:
                    menu.SaveToFile();
                    break;
                case 12:
                    menu.LoadFromFile();
                    break;
                case 13:
                    OrderMenu orderMenu = new();
                    orderMenu.DisplayMenu();
                    break;
                case 14:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid function. Please select again.");
                    break;
            }
        } while (choice != 13);
    }
}
