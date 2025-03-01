using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.VMs
{
    public class QuestionVM
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public int QuestionTypeId { get; set; }

        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
