using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Orders.Models;

namespace Orders.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<List<Order>> GetOrdersAsync();
    }

    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            this._orders = new List<Order>()
            {
                new Order(Guid.NewGuid().ToString(), "order 1", "This is order #1", 1, DateTimeOffset.UtcNow, OrderStatuses.Created),
                new Order(Guid.NewGuid().ToString(), "order 2", "This is order #2", 2, DateTimeOffset.UtcNow.AddHours(1), OrderStatuses.Processing),
                new Order(Guid.NewGuid().ToString(), "order 3", "This is order #3", 3, DateTimeOffset.UtcNow.AddHours(2), OrderStatuses.Completed),
                new Order(Guid.NewGuid().ToString(), "order 4", "This is order #4", 4, DateTimeOffset.UtcNow.AddHours(3), OrderStatuses.Cancelled),
                new Order(Guid.NewGuid().ToString(), "order 5", "This is order #5", 5, DateTimeOffset.UtcNow.AddHours(4), OrderStatuses.Closed),
            };
        }

        public Task<Order> GetOrderByIdAsync(string id)
        {
            return Task.FromResult(this._orders.SingleOrDefault(p => p.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)));
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            return Task.FromResult(this._orders);
        }
    }
}