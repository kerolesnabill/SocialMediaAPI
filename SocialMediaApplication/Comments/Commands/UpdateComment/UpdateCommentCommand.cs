using MediatR;

namespace SocialMediaApplication.Comments.Commands.UpdateComment;

public class UpdateCommentCommand : IRequest
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; } = default!;
}