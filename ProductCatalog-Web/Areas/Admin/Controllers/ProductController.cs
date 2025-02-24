using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;
using System.IO;

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
            ViewBag.Categories = GetCategories();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName);
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                product.ImageUrl = file.FileName;
                _serviceManager.ProductService.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = GetCategories();
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _serviceManager.ProductService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        private SelectList GetCategories()
        {
              return new SelectList(_serviceManager.CategoryService.GetCategories(),"Id","Name");
        }
    }
}
