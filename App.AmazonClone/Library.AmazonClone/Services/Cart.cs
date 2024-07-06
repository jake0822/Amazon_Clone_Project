using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.AmazonClone.Models;

namespace Library.AmazonClone.Services
{
    public class Cart
    {
        public string? Name { get; set; }
        public int Id { get; set; }
        private List<Item>? items;
        public Cart()
        {
            items = new List<Item>
            {
                
            };
        }

        private static Cart? instance;
        private static object instanceLock = new object();

        public static Cart Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new Cart();
                    }
                }
                return instance;
            }
        }
        public ReadOnlyCollection<Item>? Items
        {
            get
            {
                return items?.AsReadOnly();
            }
        }
        //========= functionality
        
        public void Clear()
        {
            items?.Clear();
        }
        public Item? Add(Item item)
        {
            if (items == null)
            {
                items = new List<Item>();
            }
            items.Add(item);
            return item;
        }

        public Item? Remove(Item item)//legacy method to delete items in cart for Console App
        {
            if (items == null)
            {
                return null;
            }
            items.Remove(item);
            return item;
        }
        public void Delete(int id)
        {
            if (items == null)
            {
                return;
            }
            var itemToDelete = items.FirstOrDefault(c => c.Id == id);

            if (itemToDelete != null)
            {
                items.Remove(itemToDelete);
            }
        }
        public float Savings()
        {
            
            float total = 0;
            foreach (var item in items)
            {
                total += (item.AvailableQuantity * (item.Price - item.SalePrice));
                if (item.Bogo == true)
                {
                    total += ((item.AvailableQuantity/2) * item.SalePrice);
                }
            }

            return total;
        }

        public float Total()
        {
            float _price = 0;
            
            float total = 0;
            foreach (var item in items)
            {
                //if (item.SalePrice < item.Price)
                //{
                   // _price = item.SalePrice;
                //}
                //else
               // {
                    _price = item.Price;
                //}
                total += (item.AvailableQuantity * _price);
            }

            return total;
        }
    }
}
