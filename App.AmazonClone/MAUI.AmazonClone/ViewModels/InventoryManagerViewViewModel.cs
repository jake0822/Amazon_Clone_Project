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
        public List <ItemViewModel> Items {
            get 
            {
            return Inventory.Current?.Items?.Select(i => new ItemViewModel(i)).ToList() ?? new List<ItemViewModel>();
            }
        }
        public InventoryManagerViewViewModel() { }

    }
}
