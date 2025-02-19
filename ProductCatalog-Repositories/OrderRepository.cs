using ProductCatalog_Repositories.Contexts;
using ProductCatalog_Repositories.Contracts;
using ProductCatolog_Core.DTOs;
using ProductCatolog_Core.Models;
using ProductCatolog_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalog_Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IQueryable<Order> Orders => _context.Orders.Include(o => o.Lines).ThenInclude(cl => cl.Product).OrderBy(o => o.OrderStatus).ThenByDescending(o => o.Id);

        public int NumberOfInProcess => _context.Orders.Count(o => o.OrderStatus.Equals(false));

        public void Complete(int id)
        {
            var order = FindById(id);
            if (order is null)
            {
                throw new Exception("Order not found");
            }
            order.OrderStatus = OrderStatus.Delivered;
            _context.SaveChanges();
        }

        public IQueryable<Order> GetAllOrdersByUserId(string userId)
        {
            return FindAll().Where(o => o.UserId == userId);
        }

        public Order? GetOneOrder(int id)
        {
            return FindById(id);
        }

        public IQueryable<Order> GettAllOrders() => FindAll();

        public IEnumerable<OrderUserDTO> GettAllOrdersWithUser()
        {
            return _context.Orders.Include(o => o.User).Select(o => new OrderUserDTO{OrderId = o.Id,UserName = o.User.UserName,OrderName = o.Name,OrderDate = o.CreatedDate,City = o.City,OrderStatus = o.OrderStatus}).ToList();
        }


        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.Id == 0)
            {
                _context.Orders.Add(order);
            }
            else
            {
                _context.Orders.Update(order);
            }
            _context.SaveChanges();
        }
    }
}
