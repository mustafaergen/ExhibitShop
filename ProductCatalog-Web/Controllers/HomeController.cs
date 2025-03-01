using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog_Services;
using ProductCatalog_Services.Contracts;
using ProductCatalog_Web.Models;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System.Diagnostics;

namespace ProductCatalog_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceManager _serviceManager;
        public HomeController(ILogger<HomeController> logger, IServiceManager serviceManager)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            ViewBag.Articles = GetArticles();
            return View(_serviceManager.ProductService.GetProductsByStatus(Status.Featured));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var pro = _serviceManager.ProductService.GetProduct(id);
            if (pro is null) 
                return NotFound();

            return View(pro);
                
        }
        private SelectList GetArticles()
        {
            return new SelectList(_serviceManager.ArticlesService.GetAllArticle(), "Id", "Name");
        }
    }
}
