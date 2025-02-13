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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;

        public RepositoryManager
            (RepositoryContext context, IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public IProductRepository ProductRepository => _productRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository;
        public IOrderRepository OrderRepository => _orderRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
