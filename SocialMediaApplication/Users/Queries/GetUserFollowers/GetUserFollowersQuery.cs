using MediatR;
using SocialMediaApplication.Users.Dtos;

namespace SocialMediaApplication.Users.Queries.GetUserFollowers;

public class GetUserFollowersQuery(string id) : IRequest<IEnumerable<UserMiniDto>>
{
    public string Id { get; set; } = id;
}
