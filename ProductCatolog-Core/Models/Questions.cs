using Microsoft.AspNetCore.Identity;
using ProductCatolog_Core.Abstracts;
using ProductCatolog_Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatolog_Core.Models
{
    public class Questions : BaseEntity
    {
        public string Question { get; set; } 
        public string? Answer { get; set; }
        public QuestionStatus QuestionStatus { get; set; } = QuestionStatus.Customer;
        public int? QuestionTypeId { get; set; }
        public virtual QuestionType? QuestionType { get; set; }
        public string? UserId { get; set; }
        public virtual IdentityUser? User { get; set; }
    }
}
