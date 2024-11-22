using AutoMapper;
using SocialMediaApplication.Posts.Commands.CreatePost;
using SocialMediaApplication.Posts.Commands.UpdatePost;
using SocialMediaApplication.Posts.Dtos;
using SocialMediaDomain.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaApplicationTests.Posts.Dtos;

public class PostsProfileTests
{
    private IMapper _mapper;

    public PostsProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<PostsProfile>();
        });

        _mapper = configuration.CreateMapper();
    }

    [Fact()]
    public void CreateMap_ForCreatePostCommandToPost_MapsCorrectly()
    {
        var command = new CreatePostCommand() { Content = "Content" };

        var result = _mapper.Map<Post>(command);

        Assert.NotNull(result);
        Assert.Equal(command.Content, result.Content);
    }

    [Fact()]
    public void CreateMap_ForUpdatePostCommandToPost_MapsCorrectly()
    {
        var command = new UpdatePostCommand() { Content = "NewContent" };

        var result = _mapper.Map<Post>(command);

        Assert.NotNull(result);
        Assert.Equal(command.Content, result.Content);
    }

    [Fact()]
    public void CreateMap_ForPostToPostDto_MapsCorrectly()
    {
        var post = new Post()
        { 
            Id = 1,
            Content = "Content",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now.AddDays(1),
            AuthorId = "authorId"
        };

        var result = _mapper.Map<PostDto>(post);

        Assert.NotNull(result);
        Assert.Equal(post.Id, result.Id);
        Assert.Equal(post.CreatedAt, result.CreatedAt);
        Assert.Equal(post.UpdatedAt, result.UpdatedAt);
        Assert.Equal(post.AuthorId, result.AuthorId);
        Assert.Equal(post.Content, result.Content);
    }
}