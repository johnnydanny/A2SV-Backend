using System.ComponentModel.DataAnnotations;

namespace BLOG_Console_Application.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public required int PostId { get; set; }
        [Required]
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Post? Post { get; set; }
    }
}
