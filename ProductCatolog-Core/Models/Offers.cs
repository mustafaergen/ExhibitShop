using Microsoft.AspNetCore.Identity;
using ProductCatolog_Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Models
{
    public class Offers : BaseEntity
    {
        public decimal OfferPrice { get; set; }
        public decimal? CounterPrice { get; set; }
        public int ProductCount{ get; set; }
        public string? UserId { get; set; }
        public int? ProductId { get; set; }
        public virtual IdentityUser? User { get; set; }
        public virtual Product Product { get; set; }
    }
}
