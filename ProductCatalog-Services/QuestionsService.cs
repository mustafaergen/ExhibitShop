using ProductCatalog_Repositories.UnitOfWork;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IRepositoryManager _manager;

        public QuestionsService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateQuestions(Questions questions)
        {
            _manager.QuestionsRepository.Create(questions);
            _manager.Save();
        }

        public void DeleteQuestions(int id)
        {
            var question= _manager.QuestionsRepository.FindById(id);
            if(question == null)
            {
                throw new Exception("Question is not found");
            }
            _manager.QuestionsRepository.Delete(question);
            _manager.Save();
        }

        public IEnumerable<Questions> GetQuestions()
        {
            return _manager.QuestionsRepository.FindAll().ToList();
            
        }

        public Questions GetQuestionsById(int id)
        {
            var question = _manager.QuestionsRepository.FindById(id);
            if (question == null)
            {
                throw new Exception("Question is not found");
            }
            else
            {
                return question;
            }
        }

        public IEnumerable<Questions> GetQuestionsByStatus(Status? status)
        {
            return _manager.QuestionsRepository.FindAll().Where(x=>x.Status == status).ToList();
        }

        public IEnumerable<Questions> GetQuestionsByType(int id)
        {
            return _manager.QuestionsRepository.FindAllCondition(x => x.QuestionTypeId == id).ToList();
        }


        public void UpdateQuestions(Questions questions)
        {
            var existingQuestion = _manager.QuestionsRepository.FindById(questions.Id);
            if (existingQuestion == null)
            {
                throw new Exception("Question is not found");
            }

            existingQuestion.QuestionTypeId = questions.QuestionTypeId;
            existingQuestion.Status = questions.Status;
            existingQuestion.Question = questions.Question;
            existingQuestion.Answer = questions.Answer;

            _manager.Save();
        }
    }
}
