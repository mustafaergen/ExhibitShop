using ProductCatalog_Repositories.UnitOfWork;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class CartService : ICartService
    {
        private readonly IRepositoryManager _manager;

        public CartService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<CartLine> AddProductToCartAsync(string userId, int productId, int quantity)
        {
            return await _manager.CartRepository.AddProductToCartAsync(userId, productId, quantity);
        }

        public async Task<Cart> CreateAsync(Cart cart)
        {
            return await _manager.CartRepository.CreateAsync(cart);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _manager.CartRepository.DeleteAsync(id);
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await _manager.CartRepository.GetCartByUserIdAsync(userId);
        }

        public async Task<CartLine> RemoveProductFromCartAsync(string userId, int productId)
        {
            return await _manager.CartRepository.RemoveProductFromCartAsync(userId, productId);
        }

        public Task<Cart> UpdateAsync(Cart cart)
        {
            return _manager.CartRepository.UpdateAsync(cart);
        }

    }
}
