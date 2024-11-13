using MediatR;
using System.Text.Json.Serialization;

namespace SocialMediaApplication.Comments.Commands.CreateComment;

public class CreateCommentCommand : IRequest<int>
{
    [JsonIgnore]
    public int PostId { get; set; }
    public string Content { get; set; } = default!;
}
