using MediatR;
using Microsoft.AspNetCore.Http;

namespace SocialMediaApplication.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<int>
{
    public string? Content { get; set; }
    public IFormFileCollection? Images { get; set; }
}
