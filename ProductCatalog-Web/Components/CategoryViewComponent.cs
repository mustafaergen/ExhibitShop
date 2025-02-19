using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;
using System.Reflection.Metadata.Ecma335;

namespace ProductCatalog_Web.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public CategoryViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IViewComponentResult Invoke()
        {
            var cat = _serviceManager.CategoryService.GetCategories().Where(x => x.Status == Status.Active);
            if(cat.Any())
            {
                ViewData["NoProducts"] = true;
            }
            return View(cat);
        }
    }
}
