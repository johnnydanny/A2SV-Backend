using BlogApp.Domain.Shared;

namespace BlogApp.Domain
{
    public class Post : BaseDomainEntity
    {
        public required string Title { get; set; }

        public required string Content { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();     // a post can have multiple comments
    }
}