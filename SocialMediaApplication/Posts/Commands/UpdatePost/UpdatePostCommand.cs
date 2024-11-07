using MediatR;

namespace SocialMediaApplication.Posts.Commands.UpdatePost;

public class UpdatePostCommand : IRequest
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<string>? Images { get; set; }
    public DateTime? UpdatedAt { get; } = DateTime.Now;
}
