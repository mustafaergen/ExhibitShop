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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IQueryable<Order> Orders => throw new NotImplementedException();

        public int NumberOfInProcess => throw new NotImplementedException();

        public void Complete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAllOrdersByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Order? GetOneOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
