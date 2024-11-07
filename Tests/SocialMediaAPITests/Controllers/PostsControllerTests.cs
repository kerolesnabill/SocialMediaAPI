using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Newtonsoft.Json;
using SocialMediaApplication.Posts.Commands.CreatePost;
using SocialMediaApplication.Users;
using SocialMediaDomain.Constants;
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

        var fakeUser = new CurrentUser("AuthorId", "username", "test@test.com");
        _userContext.Setup(u => u.GetCurrentUser()).Returns(fakeUser);
    }

    [Fact()]
    public async Task CreatePost_ForValidRequest_Return201Created()
    {
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

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact()]
    public async Task GetPostById_ForValidRequest_Return200Ok()
    {
        var id = 1;
        _postRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(new Post());

        var client = _factory.CreateClient();

        var response = await client.GetAsync($"api/posts/{id}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }


    [Fact()]
    public async Task GetPostById_ForNonExistingPost_Return404NotFound()
    {
        var id = 0;
        _postRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(null as Post);

        var client = _factory.CreateClient();

        var response = await client.GetAsync($"api/posts/{id}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact()]
    public async Task DeletePost_ForValidRequest_Return204NoContent()
    {
        var id = 1;
        var post = new Post() { Id = id, AuthorId = "AuthorId" };
        _postRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(post);
        _postRepository.Setup(r => r.Delete(post));

        var client = _factory.CreateClient();

        var response = await client.DeleteAsync($"api/posts/{id}");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact()]
    public async Task DeletePost_ForNonExistingPost_Return404NotFound()
    {
        var id = 0;
        _postRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(null as Post);

        var client = _factory.CreateClient();

        var response = await client.DeleteAsync($"api/posts/{id}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact()]
    public async Task DeletePost_ForNotValidAuthor_Return403Forbidden()
    {
        var id = 0;
        var post = new Post() { Id = id , AuthorId = "DifferentAuthorId" };
        _postRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(post);

        var client = _factory.CreateClient();

        var response = await client.DeleteAsync($"api/posts/{id}");

        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }
}