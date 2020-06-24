using GraphQL.Types;

using PostsQL.Services;

namespace PostsQL.Schemas
{
    public class PostsQuery : ObjectGraphType<object>
    {
        private readonly IPostService _postService;

        public PostsQuery(IPostService postService)
        {
            this._postService = postService;

            this.Name = "Query";

            this.FieldAsync<ListGraphType<PostType>>(
                "posts",
                resolve: async c => await this._postService.GetPostsAsync());

            this.FieldAsync<PostType>(
                "post",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>() { Name = "id", Description = "Post ID" }),
                resolve: async c => await this._postService.GetPostByIdAsync(c.GetArgument<int>("id")));
        }
    }
}