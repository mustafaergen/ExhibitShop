using ProductCatolog_Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Models
{
    public class QuestionType : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Questions> Questions { get; set; } = new List<Questions>();
    }
}
