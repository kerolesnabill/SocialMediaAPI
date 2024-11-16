using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;

namespace SocialMediaApplication.Users.Commands.UnassignUserRole;

public class UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommandHandler> logger,
        RoleManager<IdentityRole> roleManager,
        UserManager<User> userManager) : IRequestHandler<UnassignUserRoleCommand>
{
    public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Unassigning user role: {@Request}", request);

        var user = await userManager.FindByIdAsync(request.UserId)
            ?? throw new NotFoundException(nameof(User), request.UserId);

        var role = await roleManager.FindByNameAsync(request.RoleName)
            ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

        await userManager.RemoveFromRoleAsync(user, role.Name!);
    }
}
