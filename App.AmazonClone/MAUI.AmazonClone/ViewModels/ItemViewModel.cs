using Library.AmazonClone.Models;
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
        public ItemViewModel()
        {
            Item = new Item();
        }
        public ItemViewModel(Item i)
        {
            Item = i;
        }
        private void ExecuteEdit(ItemViewModel? p)
        {
            if (p?.Item == null)
            {
                return;
            }
            Shell.Current.GoToAsync($"//Contact?contactId={p.Item.Id}");
        }
        public ICommand EditCommand { get; private set; }
        public void SetupCommands()
        {
            EditCommand = new Command(
                (c) => ExecuteEdit(c as ItemViewModel));
        }

    }
}
