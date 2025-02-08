using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;
using ProductCatolog_Core.VMs;

namespace ProductCatalog_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        //private readonly IServiceManager _serviceManager;
        //public async Task<IActionResult> Index()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Product model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _serviceManager.ProductService.CreateOneProduct(model);
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
    }
}

