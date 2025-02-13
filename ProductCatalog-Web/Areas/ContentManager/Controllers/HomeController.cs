using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;

namespace ProductCatalog_Web.Areas.ContentManager.Controllers
{
    [Area("ContentManager")]
    [Authorize(Roles = "ContentManager")]
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Product");
        }
    }
}