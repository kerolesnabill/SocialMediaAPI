using MediatR;
using SocialMediaApplication.Users.Dtos;

namespace SocialMediaApplication.Posts.Queries.GetPostLikes;

public class GetPostLikesQuery(int id) : IRequest<IEnumerable<UserMiniDto>>
{
    public int Id { get; set; } = id;
}
