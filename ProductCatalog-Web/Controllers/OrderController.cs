using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly Cart _cart;

        public OrderController(IServiceManager serviceManager, Cart cart)
        {
            _serviceManager = serviceManager;
            _cart = cart;
        }
        [Authorize]
        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            if(_cart.Lines.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _serviceManager.OrderService.SaveOrder(order);
                return RedirectToAction("Completed", new {OrderId= order.Id});
            }
            return View(order);
        }
        [HttpGet]
        public IActionResult Completed(int OrderId)
        {
            var order = _serviceManager.OrderService.GetOneOrder(OrderId);
            ViewData["Success"] = "Congratulations, your order has been placed successfully.";
            return View(order);
        }
        [HttpGet]
        public IActionResult MyOrders()
        {
            var userId = _serviceManager.UserManager.GetUserId(User);
            var orders = _serviceManager.OrderService.GetAllOrdersByUserId(userId);
            return View(orders);
        }
    }
}
