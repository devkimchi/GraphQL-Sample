using GraphQL.Types;

namespace Orders.Schema
{
    public class OrderStatusesEnum : EnumerationGraphType
    {
        public OrderStatusesEnum()
        {
            this.Name = "OrderStatuses";

            this.AddValue(new EnumValueDefinition() { Name = "Created", Description = "Order created", Value = 1 });
            this.AddValue(new EnumValueDefinition() { Name = "Processing", Description = "Order processing", Value = 2 });
            this.AddValue(new EnumValueDefinition() { Name = "Completed", Description = "Order completed", Value = 4 });
            this.AddValue(new EnumValueDefinition() { Name = "Cancelled", Description = "Order cancelled", Value = 8 });
            this.AddValue(new EnumValueDefinition() { Name = "Closed", Description = "Order closed", Value = 16 });
        }
    }
}