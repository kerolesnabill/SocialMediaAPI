using MediatR;
using System.Text.Json.Serialization;

namespace SocialMediaApplication.Comments.Commands.UpdateComment;

public class UpdateCommentCommand : IRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public int PostId { get; set; }
    public string Content { get; set; } = default!;
}