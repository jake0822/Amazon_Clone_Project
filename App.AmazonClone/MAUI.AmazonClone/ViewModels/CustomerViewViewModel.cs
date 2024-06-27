﻿using Library.AmazonClone.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.AmazonClone.ViewModels
{
    public class CustomerViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshItems()
        {
            NotifyPropertyChanged("Items");
        }
        public CustomerViewViewModel() { }
        public List<ItemViewModel> Items
        {
            get
            {
                return Inventory.Current?.Items?.Select(i => new ItemViewModel(i)).ToList() ?? new List<ItemViewModel>();
            }
        }
    }
}
