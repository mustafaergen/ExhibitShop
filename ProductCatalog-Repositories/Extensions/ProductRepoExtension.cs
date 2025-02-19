using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories.Extensions
{
    public static class ProductRepoExtension
    {
        public static IQueryable<Product> StatusActive(this IQueryable<Product> products, Status? status)
        {
            return products.Where(x => x.Status == status);
        }

        public static IQueryable<Product> ByCatId(this IQueryable<Product> products, int? CatId)
        {
            return products.Where(x => x.CategoryId == CatId);
        }

        public static IQueryable<Product> ByCatIdAndStatus(this IQueryable<Product> products, Status? status, int? CatId)
        {
            return products.Where(x => x.Status == status && x.CategoryId == CatId);
        }
    }
}
