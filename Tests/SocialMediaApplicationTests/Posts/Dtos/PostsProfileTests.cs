using AutoMapper;
using SocialMediaApplication.Posts.Commands.CreatePost;
using SocialMediaApplication.Posts.Commands.UpdatePost;
using SocialMediaApplication.Posts.Dtos;
using SocialMediaDomain.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaApplication.Posts.Dtos;

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
        var command = new CreatePostCommand()
        {
            Title = "Title",
            Description = "Description",
            Images  = ["image1", "image2"]
        };

        var result = _mapper.Map<Post>(command);

        Assert.NotNull(result);
        Assert.Equal(command.Title, result.Content.Title);
        Assert.Equal(command.Description, result.Content.Description);
        Assert.Equal(command.Images, result.Content.Images);
    }

    [Fact()]
    public void CreateMap_ForUpdatePostCommandToPost_MapsCorrectly()
    {
        var command = new UpdatePostCommand()
        {
            Title = "Title",
            Description = "Description",
            Images = ["image1", "image2"]
        };

        var result = _mapper.Map<Post>(command);

        Assert.NotNull(result);
        Assert.Equal(command.Title, result.Content.Title);
        Assert.Equal(command.Description, result.Content.Description);
        Assert.Equal(command.Images, result.Content.Images);
    }

    [Fact()]
    public void CreateMap_ForPostToPostDto_MapsCorrectly()
    {
        var post = new Post()
        { 
            Id = 1,
            Content = new PostContent()
            {
                Title = "Title",
                Description = "Description",
                Images = ["img1", "img2"]
            },
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
        Assert.Equal(post.Content.Title, result.Title);
        Assert.Equal(post.Content.Description, result.Description);
        Assert.Equal(post.Content.Images, result.Images);
    }
}