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
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Order> Orders => _manager.OrderRepository.Orders.ToList();

        public int NumberOfInProcess => _manager.OrderRepository.NumberOfInProcess;

        public void Complete(int id)
        {
            _manager.OrderRepository.Complete(id);
            _manager.Save();
        }

        public IEnumerable<Order> GetAllOrdersByUserId(string userId)
        {
            return _manager.OrderRepository.GetAllOrdersByUserId(userId).ToList();
        }

        public Order? GetOneOrder(int id)
        {
            return _manager.OrderRepository.GetOneOrder(id);
        }

        public void SaveOrder(Order order)
        {
            _manager.OrderRepository.SaveOrder(order);
        }
    }
}
