using GraphQL.Types;

using Orders.Models;

namespace Orders.Schema
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            this.Field(p => p.Id);
            this.Field(p => p.Name);
        }
    }
}