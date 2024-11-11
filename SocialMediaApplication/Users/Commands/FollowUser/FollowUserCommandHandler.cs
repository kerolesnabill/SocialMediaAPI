using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Users.Commands.FollowUser;

public class FollowUserCommandHandler(ILogger<FollowUserCommandHandler> logger,
    IUsersRepository userRepository,
    UserManager<User> userManager,
    IUserContext userContext) : IRequestHandler<FollowUserCommand>
{
    public async Task Handle(FollowUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("User: {FollowerId} following User: {FollowingId}", currentUser!.Id, request.Id);

        var follower = await userRepository.GetByIdWithFollowingAsync(currentUser.Id)
            ?? throw new NotFoundException(nameof(User), currentUser.Id);

        if (currentUser.Id == request.Id) return;

        var following = await userManager.FindByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(User), request.Id);

        if(follower.Following.Contains(following)) return;

        await userRepository.FollowAsync(follower, following);
    }
}
