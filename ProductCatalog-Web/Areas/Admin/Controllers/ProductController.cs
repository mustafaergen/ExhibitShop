using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog_Services;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.DTOs;
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
            return View(_serviceManager.ProductService.GetAllProducts().ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _serviceManager.CategoryService.GetCategories().Select(c=> new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCreateDTO model, IFormFile file)
        {
            // Modelstate doğrulama hataları varsa işlemi iptal et
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Dosya kontrolü (boş dosya yüklenmişse)
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("ImageUrl", "Lütfen bir resim dosyası seçin.");
                return View(model);
            }

            // Dosya işlemi
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName);

            // Dosyayı kaydetme
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Dosya yolunu modele ekleme
            model.ImageUrl = file.FileName;

            // Ürünü oluşturma işlemi
            _serviceManager.ProductService.CreateOneProduct(model);

            // Başarılı mesaj
            TempData["Success"] = $"{model.Name} adlı ürün başarılı bir şekilde eklenmiştir.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _serviceManager.ProductService.GetOneProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.ProductService.UpdateOneProduct(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _serviceManager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _serviceManager.ProductService.GetOneProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

    }
}

