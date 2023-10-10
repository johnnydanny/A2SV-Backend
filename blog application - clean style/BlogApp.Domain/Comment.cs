using BlogApp.Domain.Shared;

namespace BlogApp.Domain
{
    public class Comment : BaseDomainEntity
    {
        public required int PostId { get; set; }
     
        public required string Text { get; set; }

        public virtual Post? Post { get; set; }
    }
}