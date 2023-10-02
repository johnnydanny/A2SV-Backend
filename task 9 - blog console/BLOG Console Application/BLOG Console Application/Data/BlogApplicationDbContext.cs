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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Comment>(
                entity => {
                    entity.HasOne(e => e.Post)
                        .WithMany(e => e.Comments)
                        .HasForeignKey(e => e.PostId)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Comment_Post");
                }
            );

            modelBuilder.Entity<Comment>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");

            modelBuilder.Entity<Comment>()
                .Property(p => p.CommentId)
                .UseIdentityColumn();

            modelBuilder.Entity<Post>()
                .Property(p => p.PostId)
                .UseIdentityColumn();

            modelBuilder.Entity<Post>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");


        }

    }
}
