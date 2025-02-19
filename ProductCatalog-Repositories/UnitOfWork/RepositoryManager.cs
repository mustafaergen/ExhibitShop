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
        private readonly ICartRepository _cartRepository;

        public RepositoryManager
            (RepositoryContext context, IProductRepository productRepository, IArticleRepository articleRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _cartRepository = cartRepository;
        }

        public IProductRepository ProductRepository => _productRepository;
        public IArticleRepository ArticleRepository => _articleRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository;
        public IOrderRepository OrderRepository => _orderRepository;

        public ICartRepository CartRepository => _cartRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
