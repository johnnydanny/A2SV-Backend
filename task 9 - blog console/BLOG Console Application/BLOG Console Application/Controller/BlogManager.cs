using BLOG_Console_Application.Data;
using BLOG_Console_Application.Models;
using System;

namespace BLOG_Console_Application.Controller
{
    public class BlogManager
    {
        private readonly PostManager _postManager;
        private readonly CommentManager _commentManager;

        public BlogManager(PostManager postManager, CommentManager commentManager)
        {
            _postManager = postManager;
            _commentManager = commentManager;
        }

        public bool CreatePostWithComment(string postTitle, string postContent, string commentText)
        {
            var post = _postManager.CreatePost(postTitle, postContent);
            if (post == null)
            {
                Console.WriteLine("Failed to create post.");
                return false;
            }

            var comment = _commentManager.CreateComment(post.PostId, commentText);
            if (comment == null)
            {
                Console.WriteLine("Failed to create comment.");
                _postManager.DeletePost(post.PostId);
                Console.WriteLine("Post deleted due to failed comment creation.");
                return false;
            }

            return true;
        }

        public void DisplayAllPosts()
        {
            var posts = _postManager.GetAllPosts();
            foreach (var post in posts)
            {
                Console.WriteLine($"Post ID: {post.PostId}");
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"Content: {post.Content}");
                Console.WriteLine($"Created At: {post.CreatedAt}");
                Console.WriteLine("Comments:");

                var comments = _commentManager.GetCommentsByPostId(post.PostId);

                foreach (var comment in comments)
                {
                    Console.WriteLine($"  Comment ID: {comment.CommentId}");
                    Console.WriteLine($"  Text: {comment.Text}");
                    Console.WriteLine($"  Created At: {comment.CreatedAt}");
                }
                Console.WriteLine("----------------------");
            }
        }
    }
}
