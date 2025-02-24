using Glimpse.AspNet.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;
using ProductCatolog_Core.VMs;

namespace ProductCatalog_Web.Areas.ContentManager.Controllers
{
    [Area("ContentManager")]
    [Authorize(Roles = "ContentManager")]
    public class ArticlesController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private int modelId;
        public ArticlesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View(_serviceManager.ArticlesService.GetAllArticle());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Article article, IFormFile file1, IFormFile file2, IFormFile file3)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string SaveFile(IFormFile file)
            {
                if (file == null || file.Length == 0) return null;

                string extension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(extension)) return null;

                string filePath = Path.Combine(uploadPath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return file.FileName;
            }

            article.ImageUrl1 = SaveFile(file1);
            article.ImageUrl2 = SaveFile(file2);
            article.ImageUrl3 = SaveFile(file3);

            _serviceManager.ArticlesService.CreateArticle(article);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_serviceManager.ArticlesService.GetArticle(id));
        }
        [HttpPost]
        public IActionResult Edit(Article article, IFormFile file1, IFormFile file2, IFormFile file3 )
        {
            if (file1 != null && file1.Length > 0)
            {
                var filePath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file1.FileName);
                using (var stream = new FileStream(filePath1, FileMode.Create))
                {
                     file1.CopyTo(stream);
                }
                article.ImageUrl1 = file1.FileName;
            }

            if (file2 != null && file2.Length > 0)
            {
                var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file2.FileName);
                using (var stream = new FileStream(filePath2, FileMode.Create))
                {
                     file2.CopyTo(stream);
                }
                article.ImageUrl2 = file2.FileName;
            }

            if (file3 != null && file3.Length > 0)
            {
                var filePath3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file3.FileName);
                using (var stream = new FileStream(filePath3, FileMode.Create))
                {
                     file3.CopyTo(stream);
                }
                article.ImageUrl3 = file3.FileName; 
            }
            _serviceManager.ArticlesService.UpdateArticle(article);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _serviceManager.ArticlesService.DeleteArticle(id);
            return RedirectToAction("Index");
        } 

    }
}
