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
            var products = _serviceManager.ProductService.GetProductsByAvailable();

            if (param.CatId != null)
                products = products.ByCatId(param.CatId);

           else if (param.search != null)
                products = products.BySearch(param.search);

           else if (param.MinPrice != null || param.MaxPrice != null)
                if(param.MinPrice is null || param.MinPrice > param.MaxPrice)
                    param.MinPrice = 0;
                else if (param.MaxPrice is null)
                    param.MaxPrice = decimal.MaxValue;

                products = products.ByPrice(param.MinPrice, param.MaxPrice);
            return View(products);
        }
        [Route("Product/Detail")]
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
