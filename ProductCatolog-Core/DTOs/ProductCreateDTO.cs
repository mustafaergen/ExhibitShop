using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.DTOs
{
    public record ProductCreateDTO : ProductDTO
    {
        public string? Summary { get; set; }
    }
}
