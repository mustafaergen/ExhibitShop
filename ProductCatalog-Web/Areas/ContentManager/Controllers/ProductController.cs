using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;
using System.IO;

namespace ProductCatalog_Web.Areas.ContentManager.Controllers
{
    [Area("ContentManager")]
    [Authorize(Roles = "ContentManager")]
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
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = GetCategoriesCount();
            return View(_serviceManager.ProductService.GetProduct(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product, IFormFile? file)
        {
            if (file is not null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                product.ImageUrl = file.FileName;
            }
            _serviceManager.ProductService.UpdateProduct(product);
            return RedirectToAction("Index");
        }
        private SelectList GetCategoriesCount()
        {
              return new SelectList(_serviceManager.CategoryService.GetCategories(),"Id","Name");
        }
    }
}
