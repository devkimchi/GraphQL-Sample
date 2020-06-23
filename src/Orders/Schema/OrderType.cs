using GraphQL.Types;

using Orders.Models;
using Orders.Services;

namespace Orders.Schema
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(ICustomerService customerService)
        {
            this.Field(p => p.Id);
            this.Field(p => p.Name);
            this.Field(p => p.Description);
            this.Field<CustomerType>("customer", resolve: context => customerService.GetCustomerByIdAsync(context.Source.CustomerId));
            this.Field(p => p.Created);
            this.Field<OrderStatusesEnum>("status", resolve: context => context.Source.Status);
        }
    }
}