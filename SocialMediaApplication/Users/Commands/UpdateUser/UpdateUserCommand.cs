using MediatR;

namespace SocialMediaApplication.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public string? FullName { get; set; }
    public string? Bio { get; set; }
    public string? Picture { get; set; }
}
