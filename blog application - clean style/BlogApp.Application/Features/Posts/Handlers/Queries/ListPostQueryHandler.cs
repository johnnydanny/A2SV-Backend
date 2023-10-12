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
    public class ListPostQueryHandler : IRequestHandler<ListPostQuery, List<ListPostDto>>
    {

        private readonly IPostRepository _postRepository; // remember ipostrepo is just an interface, implementation will be done is repository folder
        private readonly IMapper _mapper;

        public ListPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<ListPostDto>> Handle(ListPostQuery request, CancellationToken cancellationToken)
        {
            var posts = await  _postRepository.GetAllAsync();
            var postDtos = _mapper.Map<List<ListPostDto>>(posts);

            return postDtos;
        }
    }
}
