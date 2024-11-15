using MediatR;
using SocialMediaApplication.Users.Dtos;

namespace SocialMediaApplication.Users.Queries.SearchForUser;

public class SearchForUserQuery : IRequest<IEnumerable<UserMiniDto>>
{
    public string SearchPhase { get; set; } = default!;
}
