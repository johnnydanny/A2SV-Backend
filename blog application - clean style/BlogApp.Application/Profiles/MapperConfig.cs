using AutoMapper;
using BlogApp.Application.DTOs.Comment;
using BlogApp.Application.DTOs.Post;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Profiles
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Post, PostDto>().ReverseMap();
           // CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();
            CreateMap<Post, ListPostDto>().ReverseMap();
        }
        
    }
}
