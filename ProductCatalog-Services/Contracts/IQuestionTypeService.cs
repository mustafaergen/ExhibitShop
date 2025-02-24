using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services.Contracts
{
    public interface IQuestionTypeService
    {
        void CreateQuestionType(QuestionType questionType);
        void DeleteQuestionType(int id);
        IEnumerable<QuestionType> GetQuestionTypes();
        QuestionType GetQuestionTypeById(int id);
        void UpdateQuestionType(QuestionType questionType);

    }
}
