using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public OrderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [Authorize]
        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CheckOut(Order order)
        {
            var user = await _serviceManager.UserManager.GetUserAsync(User);
            var cart = _serviceManager.CartService.GetCartByUserIdAsync(user.Id).Result;

            if (cart == null || cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty!");
                return View(order); 
            }

            order.Lines = cart.CartLines.ToList();
            order.UserId = user.Id;
            order.OrderNumber = _serviceManager.OrderService.GenerateOrderNumber();
            

            if (ModelState.IsValid)
            {
                _serviceManager.OrderService.SaveOrder(order);
                var subject = "[ExhibitShop] - Your Order Has Been Successfully Placed!";
                var body = $"Dear {user.FirstName+" "+user.LastName},\n\nThank you for your order! Your order number is {order.OrderNumber}\n\n\n\n&copy; {DateTime.Now.Year} ExhibitShop. All Rights Reserved.";
                await _serviceManager.EmailService.SendEmailAsync(user.Email, subject, body);
                return RedirectToAction("Completed", new { OrderId = order.Id });
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
            var userId = _serviceManager.UserManager.GetUserAsync(User).Result.Id;
            var orders = _serviceManager.OrderService.GetAllOrdersByUserId(userId);
            return View(orders);
        }
        [HttpGet]
        public IActionResult Detail(int orderId)
        {
            var order = _serviceManager.OrderService.GetOneOrder(orderId);
            return View(order);
        }
        [HttpGet]
        public IActionResult ShippingStatus(string? orderNumber)
        {
            if (string.IsNullOrEmpty(orderNumber))
            {
                return View();
            }
            var order = _serviceManager.OrderService.GetOrderByOrderNumber(orderNumber);
            return View(order);
        }

    }
}
