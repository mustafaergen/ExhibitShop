using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Models
{
    public class Cart
    {
        public Cart()
        {
            Lines = new List<CartLine>();
        }
        public virtual List<CartLine> Lines { get; set; }

        public void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(l => l.Product.Id == product.Id).FirstOrDefault();

            if (line is null)
            {
                var _product = new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Summary = product.Summary
                };
                Lines.Add(new CartLine() { Product = _product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            Lines.RemoveAll(l => l.Product.Id == product.Id);
        }
        public void Clear() => Lines.Clear();
        public decimal TotalPrice() => Lines.Sum(l => l.Product.Price * l.Quantity);
    }
}
