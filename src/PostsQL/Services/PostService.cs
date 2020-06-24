using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PostsQL.Models;

namespace PostsQL.Services
{
    public interface IPostService
    {
        Task<Post> GetPostByIdAsync(int id);
        Task<List<Post>> GetPostsAsync();
    }

    public class PostService : IPostService
    {
        private readonly List<Post> _posts;

        public PostService()
        {
            this._posts = new List<Post>()
            {
                new Post(1, "Post #1", "post-1", DateTimeOffset.UtcNow.AddHours(-4), 1, PostStatus.Deleted),
                new Post(2, "Post #2", "post-2", DateTimeOffset.UtcNow.AddHours(-3), 2, PostStatus.Published),
                new Post(3, "Post #3", "post-3", DateTimeOffset.UtcNow.AddHours(-2), 3, PostStatus.Published),
                new Post(4, "Post #4", "post-4", DateTimeOffset.UtcNow.AddHours(-1), 4, PostStatus.Published),
                new Post(5, "Post #5", "post-5", DateTimeOffset.UtcNow.AddHours(0), 5, PostStatus.Created),
            };
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await Task.FromResult(this._posts.SingleOrDefault(p => p.Id.Equals(id)));
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await Task.FromResult(this._posts);
        }
         
    }
}