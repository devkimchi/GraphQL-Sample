using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PostsQL.Models;

namespace PostsQL.Services
{
    public interface IAuthorService
    {
        Task<Author> GetAuthorByIdAsync(int id);
        Task<List<Author>> GetAuthorsAsync();
    }

    public class AuthorService : IAuthorService
    {
        private readonly List<Author> _authors;

        public AuthorService()
        {
            this._authors = new List<Author>()
            {
                new Author(1, "Natasha Romanoff"),
                new Author(2, "Carol Danvers"),
                new Author(3, "Jean Grey"),
                new Author(4, "Wanda Maximoff"),
                new Author(5, "Gamora"),
            };
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await Task.FromResult(this._authors.SingleOrDefault(p => p.Id.Equals(id)));
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await Task.FromResult(this._authors);
        }
    }
}