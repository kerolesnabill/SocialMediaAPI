using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SocialMediaApplication.Posts.Commands.CreatePost;
using SocialMediaApplication.Users;
using SocialMediaDomain.Constants;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaApplicationTests.Posts.Commands.CreatePost;

public class CreatePostCommandHandlerTests
{
    [Fact()]
    public async Task Handle_ForValidCommand_ReturnsCreatedPostId()
    {
        var logger = new Mock<ILogger<CreatePostCommandHandler>>();
        var mapper = new Mock<IMapper>();

        var command = new CreatePostCommand();
        var post = new Post();

        mapper.Setup(m => m.Map<Post>(command)).Returns(post);

        var postRepository = new Mock<IPostsRepository>();
        postRepository.Setup(repo => repo.Create(It.IsAny<Post>())).ReturnsAsync(1);

        var userContext = new Mock<IUserContext>();
        var currentUser = new CurrentUser("authorId", "test@test.com", "username", []);
        userContext.Setup(u => u.GetCurrentUser()).Returns(currentUser);

        var postAuthorizationService = new Mock<IPostAuthorizationService>();
        postAuthorizationService.Setup(s => s.Authorize(post, ResourceOperation.Create)).Returns(true);

        var handler = new CreatePostCommandHandler(
            logger.Object,
            postAuthorizationService.Object,
            postRepository.Object,
            userContext.Object,
            mapper.Object
            );

        // act
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Equal(1, result);
        Assert.Equal("authorId", post.AuthorId);
        postRepository.Verify(r => r.Create(post), Times.Once);
    }
}