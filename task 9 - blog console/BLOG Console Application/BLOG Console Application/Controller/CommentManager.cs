using BLOG_Console_Application.Data;
using BLOG_Console_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLOG_Console_Application.Controller
{
    public class CommentManager
    {
        private readonly BlogApplicationDbContext _context;

        public CommentManager(BlogApplicationDbContext context)
        {
            _context = context;
        }

        public Comment? CreateComment(int postId, string text)
        {
            if (string.IsNullOrWhiteSpace(text) || postId < 0)
            {
                return null; 
            }

            var comment = new Comment
            {
                PostId = postId,
                Text = text,
                CreatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment; 
        }

        public List<Comment> GetCommentsByPostId(int postId)
        {
            return _context.Comments.Where(comment => comment.PostId == postId).ToList();
        }

        public bool UpdateComment(int commentId, string text)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId == commentId);
            if (comment != null)
            {
                comment.Text = text;
                _context.SaveChanges();
                return true; 
            }
            return false; 
        }

        public bool DeleteComment(int commentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId == commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
                return true; 
            }
            return false; 
        }
    }
}
