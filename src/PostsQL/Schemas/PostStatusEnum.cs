using GraphQL.Types;

namespace PostsQL.Schemas
{
    public class PostStatusEnum : EnumerationGraphType
    {
        public PostStatusEnum()
        {
            this.Name = "PostStatus";

            this.AddValue(new EnumValueDefinition() { Name = "Created", Description = "Post was created", Value = 1 });
            this.AddValue(new EnumValueDefinition() { Name = "Published", Description = "Post has been published", Value = 2 });
            this.AddValue(new EnumValueDefinition() { Name = "Deleted", Description = "Post was deleted", Value = 3 });
        }
    }
}