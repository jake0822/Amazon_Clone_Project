using System;
using Library.AmazonClone.Models;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myInventory = Inventory.Current;
            var state = "start";

           // myInventory.AddOrUpdate(new Item { Id = 0, Name = "Book", Description = "A book", Price = 10.99f });
           // myInventory?.Items?.ToList()?.ForEach(Console.WriteLine);

            state = startState();
            while (state != "exit")
            {
                if (state == "inventory")
                {
                    state = InventoryState();
                }
                else if (state == "shop")
                {
                    state = ShopState();
                }
                else if (state == "start")
                {
                    state = startState();
                }
            }

            
        }

        private static string InventoryState()
        {
            var state = "inventory";
            Console.WriteLine("Add an Item - a\nView Your Items - v\nRemove an Item - r\nback - b");
            var input = Console.ReadLine();
            if (input == "b")
                {
                state = "start";
            }
            else if (input == "a")
            {
                Console.WriteLine("Enter the name of the item");
                var name = Console.ReadLine();
                Console.WriteLine("Enter the description of the item");
                var description = Console.ReadLine();
                Console.WriteLine("Enter the price of the item");
                var price = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter the quantity of the item available");
                var availableQuantity = int.Parse(Console.ReadLine());
                var myInventory = Inventory.Current;
                var item = new Item { Id = 0, Name = name, Description = description, Price = price, AvailableQuantity = availableQuantity };
                myInventory.AddOrUpdate(item);
                Console.WriteLine("Item added");
                state = "inventory";
            }
            else if (input == "v")
            {
                var myInventory = Inventory.Current;
                myInventory?.Items?.ToList()?.ForEach(i => Console.WriteLine(i));
                state = "inventory";
            }
            else if (input == "r")
            {
                Console.WriteLine("Enter the id of the item to remove");
                var id = int.Parse(Console.ReadLine());
                var myInventory = Inventory.Current;
                var item = myInventory?.Items?.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    myInventory?.Delete(id);
                    Console.WriteLine("Item removed");
                }
                else
                {
                    Console.WriteLine("Item not found");
                }
                state = "inventory";
            }

            return state;
        }
        private static string ShopState()
        {
            var state = "shop";
            Console.WriteLine("Add item to cart - a");
            return state;
        }
        private static string startState()
        {
            var state = "start";
            Console.WriteLine("Welcome to Amazoon!");


            var input = string.Empty;


            while (state == "start")
            {
                Console.WriteLine("\nShop - s\nInventory Management - i\nExit Program - x");
                input = Console.ReadLine();
                if (input == "s")
                {
                    Console.WriteLine("Shop");
                    state = "shop";
                }
                else if (input == "i")
                {
                    Console.WriteLine("Inventory Management");
                    state = "inventory";
                }
                else if (input == "x")
                {
                    Console.WriteLine("Exiting program");
                    state = "exit";
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    state = "start";
                }
            }

            return state;
        }
    }
}