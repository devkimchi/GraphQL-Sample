using GraphQL;
using GraphQL.Types;

namespace PostsQL.Schemas
{
    public class PostsSchema : Schema
    {
        public PostsSchema(PostsQuery query, IDependencyResolver resolver)
        {
            this.Query = query;
            this.DependencyResolver = resolver;
        }
    }
}