using ProductCatolog_Core.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatolog_Core.Models
{
    public class Questions : BaseEntity
    {
        
        public string Question { get; set; } 
        public string Answer { get; set; } 
        public int? QuestionTypeId { get; set; }

        public virtual QuestionType? QuestionType { get; set; }
    }
}
