using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;

namespace ProductCatalog_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public OrderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var orders = _serviceManager.OrderService.GettAllOrdersWithUser();
            return View(orders);
        }
        [HttpGet]
        public IActionResult Detail(int OrderId)
        {
            var order = _serviceManager.OrderService.GetOneOrder(OrderId);
            return View(order);
        }
        [HttpGet]
        public IActionResult Complete(int OrderId)
        {
            _serviceManager.OrderService.Complete(OrderId);
            return RedirectToAction("Index");
        }
    }
}
