using ProductCatolog_Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Models
{
    public class Category : BaseEntity
    {
        public Category() { Products = new List<Product>(); }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
