using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog_Web.Areas.CustomerRelations.Controllers
{
    [Area("CustomerRelations")]
    [Authorize(Roles = "CustomerRelations")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
