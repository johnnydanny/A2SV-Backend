using Xunit;
using BLOG_Console_Application.Controller;
using BLOG_Console_Application.Data;
using BLOG_Console_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace BLOG_Console_Application.Tests
{
    public class PostManagerTests
    {
        [Fact]
        public void CreatePost_WithValidInput_ShouldCreatePost()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BlogApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new BlogApplicationDbContext(options))
            {
                var postManager = new PostManager(context);

                // Act
                var post = postManager.CreatePost("Test Title", "Test Content");

                // Assert
                Assert.NotNull(post);
                Assert.Equal("Test Title", post.Title);
                Assert.Equal("Test Content", post.Content);
            }
        }
    }
}
