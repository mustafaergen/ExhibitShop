using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog_Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
