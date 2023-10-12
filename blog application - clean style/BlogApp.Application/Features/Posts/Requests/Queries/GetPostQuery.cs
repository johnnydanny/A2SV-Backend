using BlogApp.Application.DTOs.Post;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Post.Requests.Queries
{
    public class GetPostQuery : IRequest<PostDto>
    {
        public int Id { get; set; }

    }
}
