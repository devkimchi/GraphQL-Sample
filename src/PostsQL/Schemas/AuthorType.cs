using GraphQL.Types;

using PostsQL.Models;

namespace PostsQL.Schemas
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            this.Field(p => p.Id);
            this.Field(p => p.Name);
        }
    }
}