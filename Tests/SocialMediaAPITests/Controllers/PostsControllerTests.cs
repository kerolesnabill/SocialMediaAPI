using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Newtonsoft.Json;
using SocialMediaApplication.Posts.Commands.CreatePost;
using SocialMediaApplication.Users;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;
using System.Net;
using System.Text;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaAPITests.Controllers;

public class PostsControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private Mock<IPostsRepository> _postRepository = new();
    private Mock<IUserContext> _userContext = new();

    public PostsControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                services.Replace(ServiceDescriptor.Scoped(typeof(IPostsRepository),
                    _ => _postRepository.Object));
                services.Replace(ServiceDescriptor.Scoped(typeof(IUserContext),
                    _ => _userContext.Object));
            });
        });
    }

    [Fact()]
    public async Task CreatePost_ForValidRequest_Return201Created()
    {
        var fakeUser = new CurrentUser("1", "username", "test@test.com");
        _userContext.Setup(u => u.GetCurrentUser()).Returns(fakeUser);

        _postRepository.Setup(r => r.Create(It.IsAny<Post>())).ReturnsAsync(1);

        var client = _factory.CreateClient();
        var newPost = new CreatePostCommand
        {
            Title = "Test Post",
            Description = "This is a test post."
        };
        var jsonContent = JsonConvert.SerializeObject(newPost);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");


        var response = await client.PostAsync("api/posts", httpContent);

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}