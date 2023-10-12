using BlogApp.Application.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DTOs.Comment
{
    public class CommentDto // skip 
    {
        public required string Text { get; set; }

        public required int PostId { get; set; }
    }
}
