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
        public int? MinPrice { get; set; } = 0;
        public int? MaxPrice { get; set; } = int.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;
    }
}
