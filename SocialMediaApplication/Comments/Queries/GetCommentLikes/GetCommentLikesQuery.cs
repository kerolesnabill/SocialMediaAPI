using MediatR;
using SocialMediaApplication.Users.Dtos;

namespace SocialMediaApplication.Comments.Queries.GetCommentLikes;

public class GetCommentLikesQuery : IRequest<IEnumerable<UserMiniDto>>
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
}
