using ProductCatolog_Core.DTOs;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services.Contracts
{
    public interface IQuestionsService
    {
        IEnumerable<Questions> GetQuestions();
        IEnumerable<Questions> GetQuestionsByType(int id);
        Questions GetQuestionsById(int id);
        void CreateQuestions(Questions questions);
        void UpdateQuestions(Questions questions);
        void DeleteQuestions(int id);
    }
}
