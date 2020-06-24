using GraphQL.Types;

using PostsQL.Models;
using PostsQL.Services;

namespace PostsQL.Schemas
{
    public class PostType : ObjectGraphType<Post>
    {
        private readonly IAuthorService _authorService;
        public PostType(IAuthorService authorService)
        {
            this._authorService = authorService;

            this.Field(p => p.Id);
            this.Field(p => p.Title);
            this.Field(p => p.Slug);
            this.Field(p => p.Published);
            this.FieldAsync<AuthorType>("author", resolve: async c => await this._authorService.GetAuthorByIdAsync(c.Source.AuthorId));
            this.Field<PostStatusEnum>("status", resolve: c => c.Source.Status);
        }
    }
}