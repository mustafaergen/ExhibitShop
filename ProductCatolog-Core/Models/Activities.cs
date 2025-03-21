using ProductCatolog_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Models
{
    public class Activities
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ActivityDescription { get; set; }
        public ActivityStatus ActivityStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    }
}
