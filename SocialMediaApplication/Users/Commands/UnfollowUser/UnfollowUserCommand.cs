using MediatR;

namespace SocialMediaApplication.Users.Commands.UnfollowUser;

public class UnfollowUserCommand(string id) : IRequest
{
    public string Id { get; set; } = id;
}
