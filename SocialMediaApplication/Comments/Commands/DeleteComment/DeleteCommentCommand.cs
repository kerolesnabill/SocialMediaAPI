using MediatR;

namespace SocialMediaApplication.Comments.Commands.DeleteComment;

public class DeleteCommentCommand : IRequest
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
}
