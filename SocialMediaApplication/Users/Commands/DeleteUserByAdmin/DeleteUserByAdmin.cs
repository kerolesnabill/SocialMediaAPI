using MediatR;

namespace SocialMediaApplication.Users.Commands.DeleteUserByAdmin;

public class DeleteUserByAdminCommand : IRequest
{
    public string UserId { get; set; } = default!;
}
