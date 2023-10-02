using Xunit;
using BLOG_Console_Application.Controller;
using BLOG_Console_Application.Data;
using BLOG_Console_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace BLOG_Console_Application.Tests
{
    public class CommentManagerTests
    {
        [Fact]
        public void CreateComment_WithValidInput_ShouldCreateComment()
        {

            var options = new DbContextOptionsBuilder<BlogApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new BlogApplicationDbContext(options))
            {
                var commentManager = new CommentManager(context);


                var comment = commentManager.CreateComment(1, "Test Comment");


                Assert.NotNull(comment);
                Assert.Equal("Test Comment", comment.Text);
            }
        }
    }

}