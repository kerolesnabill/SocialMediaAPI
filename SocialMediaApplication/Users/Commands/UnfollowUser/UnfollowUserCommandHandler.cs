using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Users.Commands.UnfollowUser;

public class UnfollowUserCommandHandler(ILogger<UnfollowUserCommandHandler> logger,
        IUsersRepository usersRepository,
        UserManager<User> userManager,
        IUserContext userContext) : IRequestHandler<UnfollowUserCommand>
{
    public async Task Handle(UnfollowUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("User: {FollowerId} unfollowing User: {FollowingId}", currentUser!.Id, request.Id);

        var follower = await usersRepository.GetByIdWithFollowingAsync(currentUser.Id)
            ?? throw new NotFoundException(nameof(User), currentUser.Id);

        var following = await userManager.FindByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(User), request.Id);

        await usersRepository.UnfollowAsync(follower, following);
    }
}
