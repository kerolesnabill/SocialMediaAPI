using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users;
using SocialMediaDomain.Constants;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Posts.Commands.UpdatePost;

public class UpdatePostCommandHandler(ILogger<UpdatePostCommandHandler> logger,
        IPostAuthorizationService postAuthorizationService,
        IPostsRepository postsRepository,
        IUserContext userContext,
        IMapper mapper  
        ) : IRequestHandler<UpdatePostCommand>
{
    public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("User {UserId} updating post with Id: {PostId}", user!.Id, request.Id);

        var post = await postsRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Post), request.Id.ToString());

        var isAuthorized = postAuthorizationService.Authorize(post, ResourceOperation.Update);
        if (!isAuthorized)
            throw new ForbidException();

        mapper.Map(request, post);

        await postsRepository.UpdateAsync(post);
    }
}
