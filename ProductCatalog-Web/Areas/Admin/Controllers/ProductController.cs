using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;

namespace ProductCatalog_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public IActionResult Index()
        {
            return View(_serviceManager.ProductService.GetAllProducts().ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Create(ProductVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _serviceManager.ProductService.AddProduct(model);
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
    }
}

