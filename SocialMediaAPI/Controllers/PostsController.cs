using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApplication.Posts.Commands.CreatePost;
using SocialMediaApplication.Posts.Commands.DeletePost;
using SocialMediaApplication.Posts.Queries.GetPostById;
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
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetPostById), new { id }, null);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPostById([FromRoute] int id)
    {
        var post = await mediator.Send(new GetPostByIdQuery(id));
        return Ok(post);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePost([FromRoute] int id)
    {
        await mediator.Send(new DeletePostCommand(id));
        return NoContent();
    }
}
