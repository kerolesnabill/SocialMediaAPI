using MediatR;

namespace SocialMediaApplication.Users.Commands.UnassignUserRole;

public class UnassignUserRoleCommand : IRequest
{
    public string UserId { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
