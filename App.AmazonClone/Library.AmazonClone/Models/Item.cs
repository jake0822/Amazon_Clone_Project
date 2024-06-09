using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.AmazonClone.Models
{
    public class Item
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public int Id { get; set; }
        public int AvailableQuantity { get; set; }

        public Item() 
        { 
            Name = string.Empty;
            Description = string.Empty;
            Price = 0;
            Id = 0;
            AvailableQuantity = 0;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - ${Price} - {Description} - {AvailableQuantity} available items";
        }
    }
}
