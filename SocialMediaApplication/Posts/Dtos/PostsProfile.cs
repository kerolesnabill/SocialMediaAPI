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
                    Images = c.Images.ToList(),
                }));

        CreateMap<Post, PostDto>()
            .ForMember(dto => dto.Title, options =>
                options.MapFrom(p => p.Content.Title))
            .ForMember(dto => dto.Description, options =>
                options.MapFrom(p => p.Content.Description))
            .ForMember(dto => dto.Images, options =>
                options.MapFrom(p => p.Content.Images));
    }
}
