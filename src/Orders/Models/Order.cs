using System;

namespace Orders.Models
{
    public class Order
    {
        public Order(string id, string name, string description, int customerId, DateTimeOffset created, OrderStatuses status)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.CustomerId = customerId;
            this.Created = created;
            this.Status = status;
        }


        public string Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset Created { get; private set; }
        public OrderStatuses Status { get; private set; }
    }
}