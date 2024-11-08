using MediatR;

namespace SocialMediaApplication.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<int>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<string>? Images { get; set; }
}
