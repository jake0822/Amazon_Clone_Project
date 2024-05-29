using Library.AmazonClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.AmazonClone.ViewModels
{
    internal class MainViewModel
    {
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
