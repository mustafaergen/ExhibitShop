using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Web.Areas.ContentManager.Controllers
{
    [Area("ContentManager")]
    [Authorize(Roles = "ContentManager")]
    public class OffersController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public OffersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var off = _serviceManager.OffersService.GetOffers();
            ViewBag.OffersCount = off.Count();
            return View(off);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_serviceManager.OffersService.GetOffersById(id));
        }
        [HttpPost]
        public IActionResult Edit(Offers offers)
        {
            if (offers is null)
                return NoContent();

            _serviceManager.OffersService.UpdateOffers(offers);
            return RedirectToAction("Index");
        }
    }
}
