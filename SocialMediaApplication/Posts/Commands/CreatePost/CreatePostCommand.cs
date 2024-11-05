using MediatR;

namespace SocialMediaApplication.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<int>
{
    public string Content { get; set; } = default!;
}
