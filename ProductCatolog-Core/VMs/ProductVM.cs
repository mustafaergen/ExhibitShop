using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.VMs
{
    public class ProductVM
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
    }
}
