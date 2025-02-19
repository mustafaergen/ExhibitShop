using Microsoft.AspNetCore.Identity;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IEmailService _emailService;
        private readonly ICartService _cartService;
        private readonly UserManager<Customer> _userManager;

        public ServiceManager(IProductService productService, IArticleService articleService, ICategoryService categoryService, IOrderService orderService, UserManager<Customer> userManager, IEmailService emailService, ICartService cartService)
        {
            _productService = productService;
            _articleService = articleService;
            _categoryService = categoryService;
            _orderService = orderService;
            _userManager = userManager;
            _emailService = emailService;
            _cartService = cartService;
        }

        public IProductService ProductService => _productService;
        public ICategoryService CategoryService => _categoryService;
        public IOrderService OrderService => _orderService;
        public UserManager<Customer> UserManager => _userManager;

        public IEmailService EmailService => _emailService;

        public IArticleService ArticlesService => _articleService;

        public ICartService CartService => _cartService;
    }
}
