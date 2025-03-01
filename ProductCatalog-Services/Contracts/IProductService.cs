using ProductCatolog_Core.DTOs;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByStatus(Status? status);
        IEnumerable<Product> GetProductsByCategory(int? categoryId);
        IEnumerable<Product> GetProductsByAvailable();
        Product? GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void UpdateStatus(int id, Status status);
        void DeleteProduct(int id);
    }
}
