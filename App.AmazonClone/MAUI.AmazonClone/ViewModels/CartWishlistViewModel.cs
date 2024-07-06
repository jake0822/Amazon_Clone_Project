using Library.AmazonClone.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.AmazonClone.ViewModels
{
    internal class CartWishlistViewModel : INotifyPropertyChanged
    {
        public CartWishlistViewModel() { }
        public List<Cart> Carts 
        {
            get
            {
                return CartWishlist.Current?.Carts?.ToList() ?? new List<Cart>();
            }
        
        }
        public Cart SelectedCart { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ChangeCart()
        {
            //Cart.Current = SelectedCart;
        }
    }
}
