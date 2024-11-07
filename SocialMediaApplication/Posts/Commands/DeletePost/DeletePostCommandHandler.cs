using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users;
using SocialMediaDomain.Constants;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Posts.Commands.DeletePost;

public class DeletePostCommandHandler(ILogger<DeletePostCommandHandler> logger,
        IPostsRepository postsRepository,
        IPostAuthorizationService postAuthorizationService,
        IUserContext userContext) : IRequestHandler<DeletePostCommand>
{
    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("Deleting post with Id: {PostId} By User: {UserId}", request.Id, user!.Id);

        var post = await postsRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Post), request.Id.ToString());

        bool isAuthorized = postAuthorizationService.Authorize(post, ResourceOperation.Delete);
        if (!isAuthorized)
            throw new ForbidException();

        await postsRepository.Delete(post);
    }
}
