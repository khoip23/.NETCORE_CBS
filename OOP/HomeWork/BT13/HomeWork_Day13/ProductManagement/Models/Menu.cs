// File: Menu.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using ProductManagement.Models;

public class Menu
{
    public List<Product>? list { get; set; } = new();
    private List<Order> orders = new List<Order>();
    public void ShowMenuFunction()
    {
        Console.WriteLine(@"
            1/ Add new product
            2/ Search by name
            3/ Update product price
            4/ Update product quantity in stock
            5/ Calculate total inventory value
            6/ Delete product
            7/ Show all products
            8/ Show products by price ascending
            9/ Show products by name ascending
            10/ Sort products by the last word in name
            11/ Save to file
            12/ Load from file
            13/ Manage orders
            14/ Quit
        ");
    }

    public int ChooseFunction()
    {
        return Utils.GetIntInput("Choose a function: ", "Invalid input");
    }

    public void AddProduct()
    {
        Product product = new();
        product.InputInfo();
        list?.Add(product);
        Console.WriteLine("Add new product successfully!");
    }

    public void ShowAllProducts()
    {
        if (list?.Count == 0)
        {
            Console.WriteLine("The list of products is empty!");
            return;
        }

        foreach (var item in list)
        {
            item.OutputInfo();
        }
    }

    public void DeleteProduct()
    {
        int productId = Utils.GetIntInput("Enter product ID to delete: ", "Invalid input");
        var productToRemove = list?.Find(p => p.Id == productId);
        if (productToRemove != null)
        {
            list?.Remove(productToRemove);
            Console.WriteLine("Delete successful!");
        }
        else
        {
            Console.WriteLine("Product ID not found!");
        }
    }

    public void SearchProductByName()
    {
        string name = Utils.GetStringInput("Enter product name to search: ", "Invalid input");
        var products = list?.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));
        if (products?.Count > 0)
        {
            foreach (var product in products)
            {
                product.OutputInfo();
            }
        }
        else
        {
            Console.WriteLine("No product found.");
        }
    }

    public void UpdateProductPrice()
    {
        int productId = Utils.GetIntInput("Enter product ID to update price: ", "Invalid input");

        var product = list?.Find(p => p.Id == productId);
        if (product != null)
        {
            double newPrice = Utils.GetDoubleInput("Enter new price: ", "Invalid input");
            product.Price = newPrice;
            Console.WriteLine("Price updated successfully!");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public async void SaveToFile()
    {
        string productList = JsonSerializer.Serialize(list);
        await File.WriteAllTextAsync("Products.json", productList);
        Console.WriteLine("Data saved to file successfully!");
    }

    public async void LoadFromFile()
    {
        string strProducts = await File.ReadAllTextAsync("Products.json");
        list = JsonSerializer.Deserialize<List<Product>>(strProducts);
        Console.WriteLine("Data loaded from file successfully!");
    }


    public void ShowProductsByPriceAscending()
    {
        var sortedProducts = list?.OrderBy(p => p.Price).ToList();
        Console.WriteLine("Product list sorted by price ascending:");
        foreach (var product in sortedProducts)
        {
            product.OutputInfo();
        }
    }

    public void ShowProductsByPriceDescending()
    {
        var sortedProducts = list?.OrderByDescending(p => p.Price).ToList();
        Console.WriteLine("Product list sorted by price descending:");
        foreach (var product in sortedProducts)
        {
            product.OutputInfo();
        }
    }

    public void CalculateTotalInventoryValue()
    {
        double totalValue = list?.Sum(p => p.Price * p.QuantityInStock) ?? 0;
        Console.WriteLine($"Total Inventory Value: {totalValue:C}");
    }

    public void SortProductsByName()
    {
        var sortedProducts = list?.OrderBy(p => p.Name).ToList();
        Console.WriteLine("Product list sorted by name:");
        foreach (var product in sortedProducts)
        {
            product.OutputInfo();
        }
    }

    public void UpdateProductQuantityInStock()
    {
        int productId = Utils.GetIntInput("Enter product ID to update quantity: ", "Invalid input");

        var product = list?.Find(p => p.Id == productId);
        if (product != null)
        {
            int newQuantity = Utils.GetIntInput("Enter new quantity: ", "Invalid input");
            product.QuantityInStock = newQuantity;
            Console.WriteLine("Quantity updated successfully!");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void ShowProductsByNameAscending()
    {
        var sortedProducts = list?.OrderBy(p => p.Name).ToList();
        Console.WriteLine("Product list sorted by name ascending:");
        foreach (var product in sortedProducts)
        {
            product.OutputInfo();
        }
    }

    public void SortProductsByLastWordInName()
    {
        var sortedProducts = list?.OrderBy(p => p.Name.Split(' ').Last()).ToList();
        Console.WriteLine("Product list sorted by the last word in name:");
        foreach (var product in sortedProducts)
        {
            product.OutputInfo();
        }
    }



    public void AddOrder()
    {
        int productId = Utils.GetIntInput("Enter product ID: ", "Invalid product ID.");
        int quantity = Utils.GetIntInput("Enter quantity: ", "Quantity must be a positive number.");
        string customerName = Utils.GetStringInput("Enter customer name: ", "Name cannot be empty.");
        System.Console.WriteLine("asasasasasassa:   "+list.Count);
        Product? product = list?.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            if (product.QuantityInStock >= quantity)
            {
                Order order = new Order
                {
                    OrderId = orders.Count + 1,
                    ProductId = productId,
                    Quantity = quantity,
                    CustomerName = customerName,
                    IsDelivered = false
                };
                orders.Add(order);
                Console.WriteLine("Order added successfully.");
            }
            else
            {
                Console.WriteLine("Insufficient stock for the requested quantity.");
            }
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void UpdateOrder()
    {
        int orderId = Utils.GetIntInput("Enter order ID to update: ", "Invalid order ID.");
        Order? order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order != null)
        {
            order.IsDelivered = Utils.GetBoolInput("Is the order delivered? (true/false): ", "Invalid input.");
            if (order.IsDelivered)
            {
                Product? product = list?.FirstOrDefault(p => p.Id == order.ProductId);
                if (product != null)
                {
                    if (product.QuantityInStock >= order.Quantity)
                    {
                        product.QuantityInStock -= order.Quantity;
                        Console.WriteLine("Order updated and stock adjusted.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Not enough stock to complete this order.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Order is not yet delivered.");
            }
        }
        else
        {
            Console.WriteLine("Order not found.");
        }
    }

    public void DeleteOrder()
    {
        int orderId = Utils.GetIntInput("Enter order ID to delete: ", "Invalid order ID.");
        Order? order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order != null)
        {
            orders.Remove(order);
            Console.WriteLine("Order deleted successfully.");
        }
        else
        {
            Console.WriteLine("Order not found.");
        }
    }

    public void ListOrders()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("No orders found.");
            return;
        }

        Console.WriteLine("List of Orders:");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"{"Order ID",-10} {"Product ID",-10} {"Quantity",-10} {"Customer",-20} {"Delivered",-10}");
        Console.WriteLine("--------------------------------------------------");
        foreach (var order in orders)
        {
            Console.WriteLine($"{order.OrderId,-10} {order.ProductId,-10} {order.Quantity,-10} {order.CustomerName,-20} {order.IsDelivered,-10}");
        }
        Console.WriteLine("--------------------------------------------------");
    }

}
