using MediatR;

namespace SocialMediaApplication.Users.Commands.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    public string UserId { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
