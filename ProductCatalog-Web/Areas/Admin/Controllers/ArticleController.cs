using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System.Drawing;

namespace ProductCatalog_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ArticlesController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public ArticlesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index(Status? status)
        {

            var art = _serviceManager.ArticlesService.GetAllArticle();
            if (status.HasValue)
                art = art.Where(a => a.Status == status.Value).ToList();

            ViewBag.ArticleCount = art.Count();
            return View(art);
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
        public IActionResult Edit(Article article, IFormFile? file1, IFormFile? file2, IFormFile? file3, string existingImage1, string existingImage2, string existingImage3)
        {
            if (file1 != null)
            {
                string path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file1.FileName);
                using (var stream = new FileStream(path1, FileMode.Create))
                {
                    file1.CopyTo(stream);
                }
                article.ImageUrl1 = file1.FileName;
            }
            else if (article.ImageUrl1 == "frst.png")
            {
                article.ImageUrl1 = existingImage1; 
            }
            if (file2 != null)
            {
                string path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file2.FileName);
                using (var stream = new FileStream(path2, FileMode.Create))
                {
                    file2.CopyTo(stream);
                }
                article.ImageUrl2 = file2.FileName;
            }
            else if (article.ImageUrl2 == "frst.png")
            {
                article.ImageUrl2 = existingImage2; 
            }
            if (file3 != null)
            {
                string path3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file3.FileName);
                using (var stream = new FileStream(path3, FileMode.Create))
                {
                    file3.CopyTo(stream);
                }
                article.ImageUrl3 = file3.FileName;
            }
            else if (article.ImageUrl3 == "frst.png")
            {
                article.ImageUrl3 = existingImage3; 
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
