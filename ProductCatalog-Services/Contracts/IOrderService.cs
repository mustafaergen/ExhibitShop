using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services.Contracts
{
    public interface IOrderService
    {
        IEnumerable<Order> Orders { get; }
        IEnumerable<Order> GetAllOrdersByUserId(string userId);
        Order? GetOneOrder(int id);
        void Complete(int id);
        void SaveOrder(Order order);
        int NumberOfInProcess { get; } 
    }
}
