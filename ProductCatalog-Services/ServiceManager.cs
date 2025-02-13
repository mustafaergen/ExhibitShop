using Microsoft.AspNetCore.Identity;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IEmailService _emailService;
        private readonly UserManager<Customer> _userManager; // Burada IdentityUser yerine Customer kullanıyoruz.

        public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderService orderService, UserManager<Customer> userManager, IEmailService emailService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _userManager = userManager;
            _emailService = emailService;
        }

        public IProductService ProductService => _productService;
        public ICategoryService CategoryService => _categoryService;
        public IOrderService OrderService => _orderService;
        public UserManager<Customer> UserManager => _userManager;

        public IEmailService EmailService => _emailService;
    }
}
