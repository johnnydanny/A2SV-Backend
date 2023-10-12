using AutoMapper;
using BlogApp.Application.DTOs.Post;
using BlogApp.Application.Features.Post.Requests.Queries;
using BlogApp.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Post.Handlers.Queries
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostDto>
    {
        private readonly IPostRepository _postRepository; // remember ipostrepo is just an interface, implementation will be done is repository folder
        private readonly IMapper _mapper;
        public GetPostQueryHandler(IPostRepository postRepository, IMapper mapper) {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);

            var postDto = _mapper.Map<PostDto>(post);

            return postDto;
        }
    }
}
