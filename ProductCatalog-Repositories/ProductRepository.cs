using ProductCatalog_Repositories.Contexts;
using ProductCatalog_Repositories.Contracts;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Delete(product);


        public IQueryable<Product> GetAllProducts() => FindAll();

        public IQueryable<Product> GetAllProductsByOrderPrice(bool orderByAsc = true)
        {
            return orderByAsc
                ? _context.Products.OrderBy(x => x.Price)
                : _context.Products.OrderByDescending(x => x.Price);
        }
        public Product? GetOneProduct(int id) => FindById(id);

        public void UpdateOneProduct(Product product) => Update(product);
    }
}
