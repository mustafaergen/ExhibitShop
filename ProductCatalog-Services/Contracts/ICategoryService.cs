using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        void CreateCategory(string categoryName);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
