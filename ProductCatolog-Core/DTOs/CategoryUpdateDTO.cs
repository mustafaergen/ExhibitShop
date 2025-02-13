using ProductCatolog_Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.DTOs
{
    public class CategoryUpdateDTO : CategoryDTO
    {
        public Status Status { get; set; }
    }
}
