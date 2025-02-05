using Microsoft.AspNetCore.Identity;
using ProductCatolog_Core.Abstracts;
using ProductCatolog_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Models
{
    public class Order : BaseEntity
    {
        public virtual ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        public string? Name { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? City { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.OrderReceived;
        public string? UserId { get; set; }
        public virtual IdentityUser? User { get; set; }
    }
}
