using System.ComponentModel.DataAnnotations;

namespace BLOG_API.Models
{
    public class Comment
    {
        public int CommentId { get; init; }
     
        public int PostId { get; set; }
       
        public string Text { get; set; }
        public DateTime CreatedAt { get; init; }

        public virtual Post? Post { get; set; }
    }
}
