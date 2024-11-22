using AutoMapper;
using SocialMediaApplication.Posts.Commands.CreatePost;
using SocialMediaApplication.Posts.Commands.UpdatePost;
using SocialMediaDomain.Entities;

namespace SocialMediaApplication.Posts.Dtos;

public class PostsProfile : Profile
{
    public PostsProfile()
    {
        CreateMap<CreatePostCommand, Post>();

        CreateMap<UpdatePostCommand, Post>();

        CreateMap<Post, PostDto>();
    }
}
