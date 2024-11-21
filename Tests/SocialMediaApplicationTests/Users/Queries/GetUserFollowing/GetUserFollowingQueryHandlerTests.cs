using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SocialMediaApplication.Users.Dtos;
using SocialMediaApplication.Users.Queries.GetUserFollowing;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaApplicationTests.Users.Queries.GetUserFollowing;

public class GetUserFollowingQueryHandlerTests
{
    private Mock<ILogger<GetUserFollowingQueryHandler>> _logger = new();
    private Mock<IUsersRepository> _usersRepository = new();
    private Mock<IMapper> _mapper = new();
    private GetUserFollowingQueryHandler _handler;

    public GetUserFollowingQueryHandlerTests()
    {
        _handler = new(_logger.Object, _usersRepository.Object, _mapper.Object);
    }

    [Fact()]
    public async void Handle_WithValidQuery_GetFollowingList()
    {
        string id = "userId";
        List<User> following = [new() { Id = "user1" }, new() { Id = "user2" }];
        List<UserMiniDto> followingDto = [new() { Id = "user1" }, new() { Id = "user2" }];
        User user = new() { Id = id, Following = following };

        _usersRepository.Setup(r => r.GetByIdWithFollowingAsync(id)).ReturnsAsync(user);
        _mapper.Setup(m => m.Map<IEnumerable<UserMiniDto>>(following)).Returns(followingDto);

        var result = await _handler.Handle(new(id), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(followingDto, result);
        _usersRepository.Verify(r => r.GetByIdWithFollowingAsync(id), Times.Once);
    }
}