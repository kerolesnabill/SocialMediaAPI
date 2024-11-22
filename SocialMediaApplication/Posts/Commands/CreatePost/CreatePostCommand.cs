using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApplication.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<int>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<IFormFile>? Images { get; set; }
}
