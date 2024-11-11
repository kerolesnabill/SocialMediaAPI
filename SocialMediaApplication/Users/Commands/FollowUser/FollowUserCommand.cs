using MediatR;

namespace SocialMediaApplication.Users.Commands.FollowUser;

public class FollowUserCommand(string id) : IRequest
{
    public string Id { get; set; } = id;
}
