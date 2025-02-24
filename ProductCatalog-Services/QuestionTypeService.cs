using ProductCatalog_Repositories.UnitOfWork;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IRepositoryManager _manager;

        public QuestionTypeService(IRepositoryManager repositoryManager)
        {
            _manager = repositoryManager;
        }

        public void CreateQuestionType(QuestionType questionType)
        {
            _manager.QuestionTypeRepository.Create(questionType);
            _manager.Save();
        }

        public void DeleteQuestionType(int id)
        {
            var questionType = _manager.QuestionTypeRepository.FindById(id);
            if (questionType == null)
            {
                throw new Exception("QuestionType is not found");
            }
            _manager.QuestionTypeRepository.Delete(questionType);
            _manager.Save();
        }

        public QuestionType GetQuestionTypeById(int id)
        {
            return _manager.QuestionTypeRepository.FindById(id);
        }

        public IEnumerable<QuestionType> GetQuestionTypes()
        {
            return _manager.QuestionTypeRepository.FindAll().ToList();
        }

        public void UpdateQuestionType(QuestionType questionType)
        {
            var type = _manager.QuestionTypeRepository.FindById(questionType.Id);
            if(type == null)
            {
                throw new Exception("QuestionType is not found");
            }
            else
            {
                type.Name = questionType.Name;
                type.Status = questionType.Status;
                _manager.Save();
            }
        }
    }
}
