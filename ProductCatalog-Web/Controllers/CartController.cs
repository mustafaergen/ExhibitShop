using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Cryptography;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;

namespace ProductCatalog_Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<Customer> _userManager;

        public CartController(IServiceManager serviceManager, UserManager<Customer> userManager)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _serviceManager.CartService.GetCartByUserIdAsync(user.Id);
            if(cart is null)
            {
                return View("EmptyCart");
            }
            return View(cart);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId,int quantity)
        {
            var user = await _userManager.GetUserAsync(User);
            if(user is null)
            {
                return RedirectToAction("Login", "Account");
            }
            var cart = await _serviceManager.CartService.GetCartByUserIdAsync(user.Id);
            if(cart != null)
            {
                var cartLine = cart.CartLines.FirstOrDefault(x => x.ProductId == productId);
                if (cartLine != null)
                {
                    cartLine.Quantity += 1;
                    await _serviceManager.CartService.UpdateAsync(cart);
                }
                else
                {
                    await _serviceManager.CartService.AddProductToCartAsync(user.Id, productId, 1);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            await _serviceManager.CartService.RemoveProductFromCartAsync(user.Id, productId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _serviceManager.CartService.GetCartByUserIdAsync(user.Id);
            if (cart != null)
            {
                // CartLines koleksiyonunun bir kopyasını alın
                var cartLines = cart.CartLines.ToList(); // Koleksiyonu kopyalayın

                // Kopya üzerinde işlem yapın
                foreach (var item in cartLines)
                {
                    // Karttaki her ürünü kaldırın
                    await _serviceManager.CartService.RemoveProductFromCartAsync(user.Id, item.ProductId);
                }

                // Yeni güncellenmiş cart'ı veritabanına kaydedin
                await _serviceManager.CartService.UpdateAsync(cart);
            }
            return RedirectToAction("Index");
        }

    }
}
