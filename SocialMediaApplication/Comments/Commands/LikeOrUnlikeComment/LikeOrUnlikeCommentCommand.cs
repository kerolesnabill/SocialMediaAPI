using MediatR;

namespace SocialMediaApplication.Comments.Commands.LikeOrUnlikeComment;

public class LikeOrUnlikeCommentCommand : IRequest
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
}
