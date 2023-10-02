using System.ComponentModel.DataAnnotations;

namespace BLOG_Console_Application.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public required  string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();     // a post can have multiple comments
    }
}
