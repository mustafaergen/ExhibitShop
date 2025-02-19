using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Request;
using ProductCatalog_Services.Extensions;


namespace ProductCatalog_Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager manager)
        {
            _serviceManager = manager;
        }

        public IActionResult Index(RequestParameters param)
        {
            var products = _serviceManager.ProductService.GetProductsByStatus(Status.Active);

            if (param.CatId != null)
                products = products.ByCatId(param.CatId);

            if (param.search != null)
                products = products.BySearch(param.search);

            if (param.MinPrice != null && param.MaxPrice != null && param.IsValidPrice)
                products = products.ByPrice(param.MinPrice, param.MaxPrice);

            return View(products);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _serviceManager.ProductService.GetProduct(id);
            if (model is not null)
                return View(model);
            return RedirectToPage("/Error");
        }
    }
}
