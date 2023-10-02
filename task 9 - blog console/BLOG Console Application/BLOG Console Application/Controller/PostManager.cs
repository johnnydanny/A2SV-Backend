using BLOG_Console_Application.Data;
using BLOG_Console_Application.Models;


namespace BLOG_Console_Application.Controller
{
    public class PostManager
    {
        private readonly BlogApplicationDbContext _context;

        public PostManager(BlogApplicationDbContext context)
        {
            _context = context;
        }

        public Post? CreatePost(string title, string content)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                return null; 
            }

            var post = new Post
            {
                Title = title,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };

            _context.Posts.Add(post);
            _context.SaveChanges();
            return post; 
        }

        public Post? GetPostById(int postId)
        {
            return _context.Posts.FirstOrDefault(post => post.PostId == postId);
        }

        public List<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public bool UpdatePost(int postId, string title, string content)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == postId);
            if (post != null)
            {
                post.Title = title;
                post.Content = content;
                _context.SaveChanges();
                return true;
            }
            return false; 
        }

        public bool DeletePost(int postId)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return true; 
            }
            return false; 
        }
    }
}
