using AutoMapper;
using SocialMediaApplication.Posts.Commands.CreatePost;
using SocialMediaDomain.Entities;

namespace SocialMediaApplication.Posts.Dtos;

public class PostsProfile : Profile
{
    public PostsProfile()
    {
        CreateMap<CreatePostCommand, Post>();
    }
}
