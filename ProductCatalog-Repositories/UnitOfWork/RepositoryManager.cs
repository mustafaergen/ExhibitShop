using ProductCatalog_Repositories.Contexts;
using ProductCatalog_Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories.UnitOfWork
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOffersRepository _offersRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly IActivityRepository _activityRepository;

        public RepositoryManager
            (RepositoryContext context, IProductRepository productRepository, IArticleRepository articleRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository,
        IOffersRepository offersRepository, ICartRepository cartRepository, IQuestionsRepository questionsRepository, IQuestionTypeRepository questionTypeRepository, IActivityRepository activityRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _offersRepository = offersRepository;
            _cartRepository = cartRepository;
            _questionsRepository = questionsRepository;
            _questionTypeRepository = questionTypeRepository;
            _activityRepository = activityRepository;
        }

        public IProductRepository ProductRepository => _productRepository;
        public IArticleRepository ArticleRepository => _articleRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository;
        public IOrderRepository OrderRepository => _orderRepository;
        public IOffersRepository OffersRepository=> _offersRepository;
        public ICartRepository CartRepository => _cartRepository;

        public IQuestionsRepository QuestionsRepository => _questionsRepository;

        public IQuestionTypeRepository QuestionTypeRepository => _questionTypeRepository;

        public IActivityRepository ActivityRepository => _activityRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task SaveAsync() 
        {
            await _context.SaveChangesAsync();
        }
    }
}
