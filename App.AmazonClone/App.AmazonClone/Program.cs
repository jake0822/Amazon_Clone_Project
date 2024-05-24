using System;
using Library.AmazonClone.Models;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myInventory = new Inventory();

            Console.WriteLine("Welcome to Amazoon!");
            Console.WriteLine("\nShop - s\nInventory Management - i");
            Console.ReadLine();
        }
    }
}