using MediatR;

namespace SocialMediaApplication.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public string Password { get; set; } = default!;
}
