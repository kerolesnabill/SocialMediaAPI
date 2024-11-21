using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SocialMediaApplication.Posts.Queries.GetPostLikes;
using SocialMediaApplication.Users.Dtos;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaApplicationTests.Posts.Queries.GetPostLikes;

public class GetPostLikesQueryHandlerTests
{
    private readonly Mock<ILogger<GetPostLikesQueryHandler>> _logger 
        = new Mock<ILogger<GetPostLikesQueryHandler>>();
    private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
    private readonly Mock<IPostsRepository> _postsRepository = new Mock<IPostsRepository>();
    private readonly GetPostLikesQueryHandler _handler;

    public GetPostLikesQueryHandlerTests()
    {
        _handler = new GetPostLikesQueryHandler
            (_logger.Object, _postsRepository.Object, _mapper.Object);
    }

    [Fact()]
    public async void Handle_WithValidQuery_GetUsersMiniDtoList()
    {
        int postId = 5;
        List<User> users = [new(){Id = "user1"}, new(){Id = "user2"}];
        List<UserMiniDto> userMiniDtos = [new() { Id = "user1" }, new() { Id = "user2" }];
        Post post = new() { Id = postId, Likes = users };

        _mapper.Setup(m => m.Map<IEnumerable<UserMiniDto>>(users)).Returns(userMiniDtos);
        _postsRepository.Setup(r => r.GetByIdWithLikesAsync(postId)).ReturnsAsync(post);

        var query = new GetPostLikesQuery(postId);
        var result = await _handler.Handle(query, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(userMiniDtos, result);
        _postsRepository.Verify(r => r.GetByIdWithLikesAsync(postId), Times.Once());
    }

    [Fact()]
    public async Task Handle_WithNonExistingPost_ThrowsNotFoundException()
    {
        var id = 1;
        var post = new Post() { Id = id };

        _postsRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(null as Post);

        var query = new GetPostLikesQuery(id);
        Func<Task> act = async () => await _handler.Handle(query, CancellationToken.None);

        await Assert.ThrowsAsync<NotFoundException>(act);
    }
}