using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Users.Commands.DeleteUserByAdmin;

public class DeleteUserByAdminCommandHandler(ILogger<DeleteUserByAdminCommandHandler> logger,
        IUsersRepository usersRepository,
        UserManager<User> userManager,
        IUserContext userContext) : IRequestHandler<DeleteUserByAdminCommand>
{
    public async Task Handle(DeleteUserByAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = userContext.GetCurrentUser();
        logger.LogInformation("Deleting user: {UserId}, By admin: {AdminId}", request.UserId, admin!.Id);

        var a = await userManager.FindByIdAsync(admin.Id)
            ?? throw new ForbidException();

        var user = await userManager.FindByIdAsync(request.UserId)
            ?? throw new NotFoundException(nameof(User), request.UserId);

        await usersRepository.DeleteAsync(user);
    }
}
