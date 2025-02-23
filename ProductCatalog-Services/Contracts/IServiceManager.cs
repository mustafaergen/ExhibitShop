using Microsoft.AspNetCore.Identity;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services.Contracts
{
    public interface IServiceManager 
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IOrderService OrderService { get; }
        IArticleService ArticlesService { get; }
        IEmailService EmailService { get; }
        ICartService CartService { get; }
        UserManager<Customer> UserManager { get; }
        IQuestionsService QuestionsService { get; }

    }
}
