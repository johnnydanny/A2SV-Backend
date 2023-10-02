using BLOG_Console_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace BLOG_Console_Application.Data
{

    public class BlogApplicationDbContext : DbContext
    {
        public BlogApplicationDbContext (DbContextOptions<BlogApplicationDbContext> options):
            base(options)
        { Console.WriteLine("Db context activated"); }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
