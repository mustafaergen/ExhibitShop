using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Request
{
    public class RequestParameters
    {
        public int? CatId { get; set; }
        public string? search { get; set; }
        public decimal? MinPrice { get; set; } = 0;
        public decimal? MaxPrice { get; set; } = decimal.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;
    }
}
