using ProductCatolog_Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name field is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Status field is required!")]
        public Status Status { get; set; }
    }
}
