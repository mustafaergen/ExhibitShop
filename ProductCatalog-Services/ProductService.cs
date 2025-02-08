using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductCatalog_Repositories.UnitOfWork;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneProduct(Product product)
        {
            var pro = _mapper.Map<Product>(product);
            _manager.ProductRepository.Create(pro);
            _manager.Save();
        }

        public void DeleteOneProduct(int delete)
        {
            var product = _manager.ProductRepository.GetOneProduct(delete);
            if(product != null)
            {
                _manager.ProductRepository.Delete(product);
            }
            throw new Exception("Product not found");
        }

        public IEnumerable<Product> GetAllProducts()
        { 
          return _manager.ProductRepository.GetAllProducts().ToList();
        }


        public Product? GetOneProduct(int id)
        {
            return _manager.ProductRepository.GetOneProduct(id);
        }


        public void UpdateOneProduct(Product product)
        {
            var entity = _mapper.Map<Product>(product);
            _manager.ProductRepository.Update(entity);
            _manager.Save();
        }

        public void UpdateStatus(int id, Status status)
        {
            var product = _manager.ProductRepository.GetOneProduct(id);
            if( product != null )
            {
                product.Status = status;
                _manager.ProductRepository.Update(product);
                _manager.Save();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
