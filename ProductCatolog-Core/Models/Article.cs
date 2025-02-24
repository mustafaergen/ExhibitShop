using ProductCatolog_Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Models
{
    public class Article : BaseEntity
    {
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string Development { get; set; }
        public string Conclusion { get; set; }
        public string? ImageUrl1 { get; set; } = "frst.png";
        public string? ImageUrl2 { get; set; } = "frst.png";
        public string? ImageUrl3 { get; set; } = "frst.png";
    }
}
