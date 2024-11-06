using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApplication.Posts.Commands.CreatePost;
using static System.Net.Mime.MediaTypeNames;

namespace SocialMediaAPI.Controllers;

[Route("api/posts")]
[ApiController]
[Authorize]
public class PostsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
    {
        var postId = await mediator.Send(command);
        return Created();
    }
}
