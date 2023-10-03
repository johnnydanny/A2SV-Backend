using System.ComponentModel.DataAnnotations;

namespace BLOG_API.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; init; }
    
        public string Title { get; set; }
 
        public string Content { get; set; }
        public DateTime CreatedAt { get; init; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();     // a post can have multiple comments
    }
}
