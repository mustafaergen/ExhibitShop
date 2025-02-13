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
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        CategoryDTO GetCategoryById(int id);
        void CreateCategory(CategoryDTO category);
        void UpdateCategory(CategoryDTO category);
        void DeleteCategory(int id);
    }
}
