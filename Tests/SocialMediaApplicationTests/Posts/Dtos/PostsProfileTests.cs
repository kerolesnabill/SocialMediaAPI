using AutoMapper;
using SocialMediaApplication.Posts.Commands.CreatePost;
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
}