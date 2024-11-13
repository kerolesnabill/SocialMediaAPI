using MediatR;

namespace SocialMediaApplication.Comments.Commands.CreateComment;

public class CreateCommentCommand : IRequest<int>
{
    public int PostId { get; set; }
    public string Content { get; set; } = default!;
}
