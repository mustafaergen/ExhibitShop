using Microsoft.EntityFrameworkCore;
using ProductCatalog_Repositories.Contexts;
using ProductCatalog_Repositories.Contracts;
using ProductCatalog_Repositories;
using ProductCatolog_Core.Models;

public class QuestionsRepository : RepositoryBase<Questions>, IQuestionsRepository
{
    public QuestionsRepository(RepositoryContext context) : base(context)
    {

    }

    

    List<Questions> IQuestionsRepository.GetQuestions()
    {
        return _context.Questions.Include(q => q.QuestionType).ToList();
    }
}
