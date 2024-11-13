using MediatR;
using SocialMediaApplication.Comments.Dtos;

namespace SocialMediaApplication.Comments.Queries.GetCommentById;

public class GetCommentByIdQuery : IRequest<CommentDto>
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
}
