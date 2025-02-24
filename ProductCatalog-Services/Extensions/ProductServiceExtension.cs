using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services.Extensions
{
    public static class ProductServiceExtension
    {
        public static IOrderedEnumerable<Product> GetProductsByDescendingDate(this IEnumerable<Product> products)
        {
            return products.OrderByDescending(x => x.CreatedDate);
        }

        public static IEnumerable<Product> ByCatId(this IEnumerable<Product> products, int? catId)
        {
            return products.Where(x => x.CategoryId == catId);
        }

        public static IEnumerable<Product> BySearch(this IEnumerable<Product> products, string? search)
        {
            if (string.IsNullOrEmpty(search))
                return products;
            return products.Where(x => x.Name.ToLower().Contains(search.ToLower()));
        }

        public static IEnumerable<Product> ByPrice(this IEnumerable<Product> products, decimal? min, decimal? max)
        {
            return products.Where(x => x.Price >= min && x.Price <= max);
        }
    }
}
