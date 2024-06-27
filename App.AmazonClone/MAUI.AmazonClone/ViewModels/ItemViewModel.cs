//using HealthKit;
using Library.AmazonClone.Models;
using Library.AmazonClone.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MAUI.AmazonClone.ViewModels
{
    public class ItemViewModel
    {
        public Item? Item;
        public string Name
        {
            get
            {
                return Item?.Name ?? string.Empty;
            }
            set
            {
                if (Item != null)
                {
                    Item.Name = value;
                }
            }
        }
        public string Description
        {
            get
            {
                return Item?.Description ?? string.Empty;
            }
            set
            {
                if (Item != null)
                {
                    Item.Description = value;
                }
            }
        }
        public int Id
        {
            get
            {
                return Item?.Id ?? 0;
            }
            set
            {
                if (Item != null)
                {
                    Item.Id = value;
                }
            }
        }
        public float Price
        {
            get
            {
                return Item?.Price ?? 0;
            }
            set
            {
                if (Item != null)
                {
                    Item.Price = value;
                }
            }
        }
        public int AvailableQuantity
        {
            get
            {
                return Item?.AvailableQuantity ?? 0;
            }
            set
            {
                if (Item != null)
                {
                    Item.AvailableQuantity = value;
                }
            }
        }

        public ItemViewModel()
        {
            Item = new Item();
        }
        public ItemViewModel(Item i)
        {
            Item = i;
            SetupCommands();
        }
        public void Add()
        {
           Inventory.Current?.AddOrUpdate(Item);
        }
        private void ExecuteEdit(ItemViewModel? p)
        {
            if (p?.Item == null)
            {
                return;
            }
            Shell.Current.GoToAsync($"//Item?itemId={p.Item.Id}");
        }
        private void ExecuteDelete(int? id)
        {
            if(id == null)
            {  
                return;
            }

            Inventory.Current.Delete(id ?? 0);
               

        }
        private void ExecuteRemoveFromCart(int? id)
        {
            var myInventory = Inventory.Current;
            var item = myInventory?.Items?.FirstOrDefault(i => i.Id == id);
            var cartItem = Cart.Current?.Items?.FirstOrDefault(i => i.Id == id);
            if (id == null)
            {
                return;
            }
            if (item != null && cartItem != null)
            {
                if (cartItem.AvailableQuantity > 0)
                {
                    cartItem.AvailableQuantity--;
                    item.AvailableQuantity++;
                }
                if (cartItem.AvailableQuantity == 0)
                {
                    Cart.Current.Delete(id ?? 0);
                }
            }
            else
            {

                Cart.Current.Delete(id ?? 0);
            }
        }
        private void ExecuteAddToCart(ItemViewModel? p)
        {
            
            var myInventory = Inventory.Current;
            var item = myInventory?.Items?.FirstOrDefault(i => i.Id == p.Id);
            var cartItem = Cart.Current?.Items?.FirstOrDefault(i => i.Id == p.Id);
            if (p?.Item == null)
            {
                return;
            }
            if (item != null && item.AvailableQuantity > 0)
            {
                var myCart = Cart.Current;
                if (cartItem != null)
                {
                    cartItem.AvailableQuantity++;
                    item.AvailableQuantity--;

                }
                else
                {
                    myCart.Add(new Item
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        AvailableQuantity = 1
                    });
                    item.AvailableQuantity--;
                }
            }
            
        }
        public ICommand AddToCartCommand { get; private set; }
        public ICommand RemoveFromCartCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
    public void SetupCommands()
        {
            EditCommand = new Command(
                (c) => ExecuteEdit(c as ItemViewModel));
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ItemViewModel)?.Item?.Id));
            RemoveFromCartCommand = new Command(
                (c) => ExecuteRemoveFromCart((c as ItemViewModel)?.Item?.Id));
            AddToCartCommand = new Command(
                (c) => ExecuteAddToCart(c as ItemViewModel));

        }
        public ItemViewModel(int id)
        {
            Item = Inventory.Current?.Items?.FirstOrDefault(c => c.Id == id);
            if (Item == null)
            {
                Item = new Item();
            }
        }

        
    }
}
