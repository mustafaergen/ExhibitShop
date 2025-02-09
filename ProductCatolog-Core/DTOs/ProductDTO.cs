using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.DTOs
{
    public record ProductDTO
    {
        public int Id { get; init; }

        [Required(ErrorMessage = "Name field is required!")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Price field is required!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero!")]
        public decimal Price { get; init; }

        public string ImageUrl { get; set; }
        public Status Status { get; set; }

        [Required(ErrorMessage = "CategoryId field is required!")]
        public int? CategoryId { get; init; }
    }
}
