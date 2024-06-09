using Library.AmazonClone.Models;
using Library.AmazonClone.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.AmazonClone.ViewModels
{
    public class InventoryManagerViewViewModel
    {
        public List <Item> Items {
            get 
            {
            return Inventory.Current?.Items?.ToList() ?? new List<Item>();
            }
        }
        public InventoryManagerViewViewModel() { }

    }
}
