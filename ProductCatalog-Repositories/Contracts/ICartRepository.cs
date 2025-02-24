using ProductCatalog_Repositories.Contracts.Base;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories.Contracts
{
    public interface ICartRepository 
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task<CartLine> AddProductToCartAsync(string userId, int productId, int quantity);
        Task<CartLine> RemoveProductFromCartAsync(string userId, int productId);
        Task<Cart> CreateAsync(Cart cart);
        Task<Cart> UpdateAsync(Cart cart);
        Task<bool> DeleteAsync(int id);
    }
}
