﻿using ProductCatalog_Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories.UnitOfWork
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        IArticleRepository ArticleRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOffersRepository OffersRepository { get; }
        ICartRepository CartRepository { get; }
        IQuestionsRepository QuestionsRepository { get; }
        IQuestionTypeRepository QuestionTypeRepository { get; }
        IActivityRepository ActivityRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
