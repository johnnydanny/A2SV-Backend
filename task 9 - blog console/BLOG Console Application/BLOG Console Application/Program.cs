using BLOG_Console_Application.Controller;
using BLOG_Console_Application.Data;
using Microsoft.EntityFrameworkCore;
using System;

var defaultString = "Server=localhost;Port=5432;Database=BlogApp;Username=postgres;Password=putyourpassword";

var options = new DbContextOptionsBuilder<BlogApplicationDbContext>()
    .UseNpgsql(defaultString)
    .Options;

using (var context = new BlogApplicationDbContext(options))
{
    context.Database.EnsureCreated();

    var postManager = new PostManager(context);
    var commentManager = new CommentManager(context);
    var blogManager = new BlogManager(postManager, commentManager);

    while (true)
    {
        Console.WriteLine("Blogging Application");
        Console.WriteLine("1. Create Post");
        Console.WriteLine("2. Read Posts");
        Console.WriteLine("3. Create Comment");
        Console.WriteLine("4. Read Comments");
        Console.WriteLine("5. Create Post with Comment");
        Console.WriteLine("6. Exit");
        Console.Write("Select an option: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    Console.Write("Enter post title: ");
                    string postTitle = Console.ReadLine();
                    Console.Write("Enter post content: ");
                    string postContent = Console.ReadLine();
                    var postCreated = postManager.CreatePost(postTitle, postContent);

                    if (postCreated != null)
                    {
                        Console.WriteLine("Post created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to create post.");
                    }
                    break;

                case 2:
                    blogManager.DisplayAllPosts();
                    break;

                case 3:
                    Console.Write("Enter post ID for the comment: ");
                    if (int.TryParse(Console.ReadLine(), out int postIdForComment))
                    {
                        var postForComment = postManager.GetPostById(postIdForComment);
                        if (postForComment != null)
                        {
                            Console.Write("Enter comment text: ");
                            string commentText = Console.ReadLine();
                            var commentCreated = commentManager.CreateComment(postForComment.PostId, commentText);

                            if (commentCreated != null)
                            {
                                Console.WriteLine("Comment created successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to create comment.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Post not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                    break;

                case 4:
                    Console.Write("Enter post ID to view comments: ");
                    if (int.TryParse(Console.ReadLine(), out int postIdForComments))
                    {
                        var postForComments = postManager.GetPostById(postIdForComments);
                        if (postForComments != null)
                        {
                            var comments = commentManager.GetCommentsByPostId(postForComments.PostId);
                            Console.WriteLine($"Comments for the post '{postForComments.Title}':");
                            foreach (var comment in comments)
                            {
                                Console.WriteLine($"Comment ID: {comment.CommentId}");
                                Console.WriteLine($"Text: {comment.Text}");
                                Console.WriteLine($"Created At: {comment.CreatedAt}");
                                Console.WriteLine("----------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Post not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                    break;

                case 5:
                    Console.Write("Enter post title: ");
                    string newPostTitle = Console.ReadLine();
                    Console.Write("Enter post content: ");
                    string newPostContent = Console.ReadLine();
                    Console.Write("Enter comment text: ");
                    string newCommentText = Console.ReadLine();
                    var postWithCommentCreated = blogManager.CreatePostWithComment(newPostTitle, newPostContent, newCommentText);
                    if (postWithCommentCreated)
                    {
                        Console.WriteLine("Post and comment created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to create post or comment.");
                    }
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}
