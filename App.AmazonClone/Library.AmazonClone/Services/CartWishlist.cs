using Library.AmazonClone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.AmazonClone.Services
{
    public class CartWishlist
    {
        private List<Cart>? carts;
        public CartWishlist() 
        {
            carts = new List<Cart> 
            { 
            new Cart{ Name = "Default Cart"  },
            new Cart{ Name = "Wishlist Cart" }
            }; 
            carts[0].Add(new Item { Name = "Ranch", Id = 99, AvailableQuantity = 2, Price = 2.99f });
        }
        private static CartWishlist? instance;
        private static object instanceLock = new object();

        public static CartWishlist Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CartWishlist();
                    }
                }
                return instance;
            }
        }

        public ReadOnlyCollection<Cart>? Carts
        {
            get
            {
                return carts?.AsReadOnly();
            }
        }
        //========= functionality
        public int LastId
        {
            get
            {
                if (carts?.Any() ?? false)
                {
                    return carts?.Select(c => c.Id)?.Max() ?? 0;
                }
                return 0;
            }
        }
        public Cart? Add(Cart cart) 
        {             
            if (carts == null)
            {
                carts = new List<Cart>();
            }
            var isAdd = false;

            if (cart.Id == 0)
            {
                cart.Id = LastId + 1;
                isAdd = true;
            }

            carts.Add(cart);
            return cart;
        }
        public Cart? Remove(Cart cart)
        {
            if (carts == null)
            {
                return null;
            }
            carts.Remove(cart);
            return cart;
        }

    }
}
