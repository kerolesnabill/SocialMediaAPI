using MediatR;
using SocialMediaApplication.Users.Dtos;

namespace SocialMediaApplication.Users.Queries.GetUserFollowing;

public class GetUserFollowingQuery(string id) : IRequest<IEnumerable<UserMiniDto>>
{
    public string Id { get; set; } = id;
}
