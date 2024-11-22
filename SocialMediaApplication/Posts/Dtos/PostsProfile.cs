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

        CreateMap<UpdatePostCommand, Post>()
           .ForMember(p => p.Content, opt => opt.Condition(c => c.Content != null))
           .ForMember(p => p.Images, opt => opt.Condition(c => c.Images != null));

        CreateMap<Post, PostDto>();
    }
}
