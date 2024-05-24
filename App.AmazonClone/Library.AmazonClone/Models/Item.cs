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

        public Item() { }

    }
}
