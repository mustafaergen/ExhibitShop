using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View(_serviceManager.ProductService.GetAllProducts());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesCount();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.ProductService.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = GetCategoriesCount();
            return View(_serviceManager.ProductService.GetProduct(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _serviceManager.ProductService.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _serviceManager.ProductService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        private SelectList GetCategoriesCount()
        {
              return new SelectList(_serviceManager.CategoryService.GetCategories(),"Id","Name");
        }
    }
}
