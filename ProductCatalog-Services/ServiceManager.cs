using Microsoft.AspNetCore.Identity;
using ProductCatalog_Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly UserManager<IdentityUser> _userManager;

        public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderService orderService, UserManager<IdentityUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _userManager = userManager;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;

        public UserManager<IdentityUser> UserManager => _userManager;
    }
}
