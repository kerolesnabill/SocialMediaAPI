using MediatR;
using Microsoft.AspNetCore.Identity;

namespace SocialMediaApplication.Users.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<IdentityResult>
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string FullName { get; set; } = default!;
}
