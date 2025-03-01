using ProductCatolog_Core.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Summary { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = "picture.png";
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

    }
}
