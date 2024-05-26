using System;
using Library.AmazonClone.Models;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Item> fart = new List<Item>();
            //fart.Add(new Item { Name = "jake" });
            //fart.ForEach(i => Console.WriteLine(i.Name));

            var myCart = Cart.Current;
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
            List<Item> cart = new List<Item>();
            var state = "shop";
            Console.WriteLine("Shop available items - s\nAdd item to cart - a\nRemove item from cart - r\nView cart - v\nCheckout - c\nBack - b");
            var input = Console.ReadLine();
            if (input == "b")
            {
                state = "start";
            }
            else if (input == "s") {                 
                var myInventory = Inventory.Current;
                myInventory?.Items?.ToList()?.ForEach(i => Console.WriteLine(i));
                state = "shop";
            }
            else if (input == "a")
            {
                Console.WriteLine("Enter the id of the item to add to cart");
                var id = int.Parse(Console.ReadLine());
                var myInventory = Inventory.Current;
                
                var item = myInventory?.Items?.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    Console.WriteLine("Enter the quantity of the item to add to cart");
                    var quantity = int.Parse(Console.ReadLine());
                    if (quantity <= item.AvailableQuantity)
                    {
                        item.AvailableQuantity -= quantity;
                        var myCart = Cart.Current;
                        myCart.Add(new Item { Id = item.Id, Name = item.Name, Description = item.Description, Price = item.Price, AvailableQuantity = quantity });

                        Console.WriteLine("Item added to cart");
                    }
                    else
                    {
                        Console.WriteLine("Not enough items available");
                    }
                }
                else
                {
                    Console.WriteLine("Item not found");
                }
                state = "shop";
            }
            else if (input == "r")
            {
                Console.WriteLine("Enter the id of the item to remove from cart");
                var id = int.Parse(Console.ReadLine());
                var myInventory = Inventory.Current;
                var myCart = Cart.Current;
                var item = myInventory?.Items?.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    Console.WriteLine("Enter the quantity of the item to remove from cart");
                    var quantity = int.Parse(Console.ReadLine());
                    var cartItem = myCart?.Items?.FirstOrDefault(i => i.Id == id);
                    if (quantity < cartItem.AvailableQuantity)
                    {
                        cartItem.AvailableQuantity -= quantity;
                    }
                    else if (quantity >= cartItem.AvailableQuantity)
                        myCart?.Remove(cartItem);

                    item.AvailableQuantity += quantity;

                    Console.WriteLine("Item removed from cart");
                }
                else
                {
                    Console.WriteLine("Item not found");
                }
                state = "shop";
            }
            else if (input == "v")
            {
                var myCart = Cart.Current;
                myCart?.Items?.ToList()?.ForEach(i => Console.WriteLine($"[{i.Id}] {i.Name} - number in cart: {i.AvailableQuantity}"));
                state = "shop";
            }
            else if (input == "c")
            {
                Console.WriteLine("Checkout");
                itemizedReceipt();
                state = "start";
            }
            else
            {
                Console.WriteLine("Invalid input");
                state = "shop";
            }
            
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

        static void itemizedReceipt()
        {
            var myCart = Cart.Current;
            var myInventory = Inventory.Current;
            float subtotal = 0;
            myCart?.Items?.ToList()?.ForEach(i => Console.WriteLine($"[{i.Id}] {i.Name} - ${i.Price} - {i.AvailableQuantity} in cart"));
            myCart?.Items?.ToList()?.ForEach(i => subtotal += (float)(i.Price * i.AvailableQuantity));
            float tax = (float)Math.Round(subtotal * 0.07f, 2);
            float total = subtotal + tax;
            Console.WriteLine($"Subtotal: ${subtotal}\nTax: ${tax}\nTotal: ${total}\n---------------------------");
        }
    }
}