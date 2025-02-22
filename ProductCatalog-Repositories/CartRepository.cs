using Microsoft.EntityFrameworkCore;
using ProductCatalog_Repositories.Contexts;
using ProductCatalog_Repositories.Contracts;
using ProductCatolog_Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly RepositoryContext _context;

        public CartRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            var cart = await _context.Carts.Include(c => c.CartLines).ThenInclude(cl => cl.Product).FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartLines = new List<CartLine>() };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            return cart;
        }

        public async Task<CartLine> AddProductToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId, CreatedDate = DateTime.Now };
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }

            var existingCartLine = cart.CartLines.FirstOrDefault(cl => cl.ProductId == productId);
            if (existingCartLine != null)
            {
                existingCartLine.Quantity += quantity;
                existingCartLine.Price = existingCartLine.Product.Price * existingCartLine.Quantity;
            }
            else
            {
                var product = await _context.Products.FindAsync(productId);
                if (product != null)
                {
                    var cartLine = new CartLine
                    {
                        CartId = cart.Id,
                        ProductId = productId,
                        Quantity = quantity,
                        Price = product.Price * quantity,
                        Product = product
                    };
                    cart.CartLines.Add(cartLine);
                }
            }

            await _context.SaveChangesAsync();
            return cart.CartLines.FirstOrDefault(cl => cl.ProductId == productId);
        }

        public async Task<CartLine> RemoveProductFromCartAsync(string userId, int productId)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart == null)
                return null;

            var cartLine = cart.CartLines.FirstOrDefault(cl => cl.ProductId == productId);
            if (cartLine != null)
            {
                cart.CartLines.Remove(cartLine);
                await _context.SaveChangesAsync();
            }

            return cartLine;
        }

        public async Task<Cart> CreateAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
                return false;

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
