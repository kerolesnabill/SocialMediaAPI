using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SocialMediaApplication.Posts.Dtos;
using SocialMediaApplication.Posts.Queries.GetFeed;
using SocialMediaApplication.Users;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaApplicationTests.Posts.Queries.GetFeed;

public class GetFeedQueryHandlerTests
{
    private readonly Mock<ILogger<GetFeedQueryHandler>> _logger
    = new Mock<ILogger<GetFeedQueryHandler>>();
    private readonly Mock<IMapper> _mapper = new();
    private readonly Mock<IPostsRepository> _postsRepository = new();
    private readonly Mock<IUsersRepository> _usersRepository = new();
    private readonly Mock<IUserContext> _userContext = new();
    private readonly GetFeedQueryHandler _handler;

    public GetFeedQueryHandlerTests()
    {
        _handler = new GetFeedQueryHandler
            (_logger.Object, _postsRepository.Object,_usersRepository.Object, _userContext.Object, _mapper.Object);
    }

    [Fact()]
    public async void Handle_WithValidQuery_GetPosts()
    {
        var currentUser = new CurrentUser("id", "email@e.com", "Username", []);
        var user = new User() { Id = "id" };
        List<Post> posts = [new() { Id = 1}, new() { Id = 2 }];
        List<PostDto> postsDto = [new() { Id = 1}, new() { Id = 2 }];

        _userContext.Setup(c => c.GetCurrentUser()).Returns(currentUser);
        _usersRepository.Setup(r => r.GetByIdWithFollowingAsync(currentUser.Id)).ReturnsAsync(user);
        _postsRepository.Setup(r => r.GetFeedAsync(user, 10, 1, null)).ReturnsAsync((posts, 2));
        _mapper.Setup(m => m.Map<IEnumerable<PostDto>>(posts)).Returns(postsDto);

        var result = await _handler.Handle(new GetFeedQuery(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(postsDto, result.Items);
        Assert.Equal(2, result.TotalItemsCount);
        _usersRepository.Verify(r => r.GetByIdWithFollowingAsync(currentUser.Id), Times.Once);
        _postsRepository.Verify(r => r.GetFeedAsync(user, 10, 1, null), Times.Once);
    }
}