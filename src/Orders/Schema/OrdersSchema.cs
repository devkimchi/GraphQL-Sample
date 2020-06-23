using GraphQL;

namespace Orders.Schema
{
    public class OrdersSchema : GraphQL.Types.Schema
    {
        public OrdersSchema(OrdersQuery query, IDependencyResolver resolver)
        {
            this.Query = query;
            this.DependencyResolver = resolver;
        }
    }
}