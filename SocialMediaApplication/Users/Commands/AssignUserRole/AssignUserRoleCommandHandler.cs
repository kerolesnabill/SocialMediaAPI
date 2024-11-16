using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;

namespace SocialMediaApplication.Users.Commands.AssignUserRole;

public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger,
        RoleManager<IdentityRole> roleManager,
        UserManager<User> userManager) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning user role: {@Request}", request);

        var user = await userManager.FindByIdAsync(request.UserId)
            ?? throw new NotFoundException(nameof(User), request.UserId);

        var role = await roleManager.FindByNameAsync(request.RoleName)
            ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

        await userManager.AddToRoleAsync(user, role.Name!);
    }
}
