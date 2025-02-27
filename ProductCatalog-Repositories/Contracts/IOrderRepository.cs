using ProductCatalog_Repositories.Contracts.Base;
using ProductCatolog_Core.DTOs;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(int id);
        IQueryable<Order> GetAllOrdersByUserId(string userId);
        IEnumerable<OrderUserDTO> GettAllOrdersWithUser();
        IQueryable<Order> GettAllOrders();
        Order? GetOrderByOrderNumber(string orderNumber);
        void Complete(int id);
        void SaveOrder(Order order);
        int NumberOfInProcess { get; }
        string GenerateOrderNumber();
    }
}
