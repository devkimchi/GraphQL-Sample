using System;

namespace PostsQL.Models
{
    public class Post
    {
        public Post(int id, string title, string slug, DateTimeOffset published, int authorId, PostStatus status)
        {
            this.Id = id;
            this.Title = title;
            this.Slug = slug;
            this.Published = published;
            this.AuthorId = authorId;
            this.Status = status;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTimeOffset Published { get; set; }
        public int AuthorId { get; set; }
        public PostStatus Status { get; set; }
    }
}