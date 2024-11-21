using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SocialMediaApplication.Users.Dtos;
using SocialMediaApplication.Users.Queries.SearchForUser;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaApplicationTests.Users.Queries.SearchForUser;

public class SearchForUserQueryHandlerTests
{
    private Mock<ILogger<SearchForUserQueryHandler>> _logger = new();
    private Mock<IUsersRepository> _usersRepository = new();
    private Mock<IMapper> _mapper = new();
    private SearchForUserQueryHandler _handler;

    public SearchForUserQueryHandlerTests()
    {
        _handler = new(_logger.Object, _usersRepository.Object, _mapper.Object);
    }

    [Fact()]
    public async void Handle_WithValidQuery_GetFollowersList()
    {
        string searchPhase = "user";
        List<User> users = [new() { Id = "user1" }, new() { Id = "user2" }];
        List<UserMiniDto> usersDto = [new() { Id = "user1" }, new() { Id = "user2" }];

        _usersRepository.Setup(r => r.FindManyContains(searchPhase)).ReturnsAsync(users);
        _mapper.Setup(m => m.Map<IEnumerable<UserMiniDto>>(users)).Returns(usersDto);

        var result = await _handler.Handle(new() { SearchPhase = searchPhase}, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(usersDto, result);
        _usersRepository.Verify(r => r.FindManyContains(searchPhase), Times.Once);
    }
}