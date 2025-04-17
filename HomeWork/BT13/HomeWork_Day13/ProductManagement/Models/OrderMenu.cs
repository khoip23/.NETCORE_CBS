using System;
using System.Collections.Generic;
using System.Linq;
using ProductManagement.Models;

public class OrderMenu
{
  
    public OrderMenu(){
      
    }


    public void DisplayMenu()
    {
        Menu menu= new Menu();
        menu.LoadFromFile();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Order Management Menu:");
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. List Orders");
            Console.WriteLine("3. Update Order");
            Console.WriteLine("4. Delete Order");
            Console.WriteLine("5. Exit");        
            int choice = Utils.GetIntInput("Choose fuction: ", "Invalid input");
            switch (choice)
            {
                case 1:
                    menu.AddOrder();
                    break;
                    
                case 2:
                    menu.ListOrders();
                    break;
                case 3:
                    menu.UpdateOrder();
                    break;
                case 4:
                    menu.DeleteOrder();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

  
}