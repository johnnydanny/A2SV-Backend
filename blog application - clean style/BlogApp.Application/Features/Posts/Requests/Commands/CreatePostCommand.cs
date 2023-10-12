using BlogApp.Application.DTOs.Post;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Post.Requests.Commands
{
    public class CreatePostCommand : IRequest<CreatePostDto>
    {
        public CreatePostDto CreatePostDto { get;}
        public CreatePostCommand(CreatePostDto post) 
        {
            CreatePostDto = post;
        }
    }
}
