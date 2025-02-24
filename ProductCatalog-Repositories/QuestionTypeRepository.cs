using ProductCatalog_Repositories.Contexts;
using ProductCatalog_Repositories.Contracts;
using ProductCatalog_Repositories.Contracts.Base;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories
{
    public class QuestionTypeRepository : RepositoryBase<QuestionType>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
