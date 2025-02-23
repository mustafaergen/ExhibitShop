﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Models
{
    public class QuestionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Questions> Questions { get; set; }
    }
}
