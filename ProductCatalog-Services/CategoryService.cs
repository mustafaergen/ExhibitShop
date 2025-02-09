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
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateCategory(string categoryName)
        {
            var cat = new Category { Name = categoryName };
            _manager.CategoryRepository.Create(cat);
            _manager.Save();
        }

        public void DeleteCategory(int id)
        {
            var cat = _manager.CategoryRepository.FindById(id);
            _manager.CategoryRepository.Delete(cat);
            _manager.Save();
        }

        public IEnumerable<Category> GetCategories()
        {
            if (_manager == null)
            {
                throw new Exception("❌ HATA: _manager nesnesi NULL!");
            }

            if (_manager.CategoryRepository == null)
            {
                throw new Exception("❌ HATA: _manager.CategoryRepository NULL!");
            }
            return _manager.CategoryRepository.FindAll().ToList();
        }

        public Category GetCategoryDTOById(int id)
        {
            var cat = _manager.CategoryRepository.FindById(id);
            return new Category { Id = cat.Id, Name = cat.Name, Status = cat.Status };
        }

        public void UpdateCategory(Category category)
        {
            var cat = _manager.CategoryRepository.FindById(category.Id);
            cat.Name = category.Name;
            cat.Status = category.Status;
            _manager.CategoryRepository.Update(cat);
            _manager.Save();
        }
    }
}
