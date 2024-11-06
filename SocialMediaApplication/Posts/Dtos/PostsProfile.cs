using AutoMapper;
using SocialMediaApplication.Posts.Commands.CreatePost;
using SocialMediaDomain.Entities;

namespace SocialMediaApplication.Posts.Dtos;

public class PostsProfile : Profile
{
    public PostsProfile()
    {
        CreateMap<CreatePostCommand, Post>()
            .ForMember(p => p.Content, options =>
                options.MapFrom(c => new PostContent
                {
                    Title = c.Title,
                    Description = c.Description,
                    Images = c.Images,
                }));
    }
}
