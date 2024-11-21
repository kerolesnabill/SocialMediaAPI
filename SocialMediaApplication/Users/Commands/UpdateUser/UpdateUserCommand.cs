using MediatR;
using Microsoft.AspNetCore.Http;

namespace SocialMediaApplication.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public string? FullName { get; set; }
    public string? Bio { get; set; }
    public IFormFile? Picture { get; set; }
}
