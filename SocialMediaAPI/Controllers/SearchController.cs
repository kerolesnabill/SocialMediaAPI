using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApplication.Posts.Queries.GetAllPosts;
using SocialMediaApplication.Users.Queries.SearchForUser;

namespace SocialMediaAPI.Controllers;

[Route("api/search")]
[ApiController]
[Authorize]
public class SearchController(IMediator mediator) : ControllerBase
{

    [HttpGet("posts")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPosts([FromQuery] GetAllPostsQuery query)
    {
        var posts = await mediator.Send(query);
        return Ok(posts);
    }

    [HttpGet("users")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsers([FromQuery] SearchForUserQuery query)
    {
        var posts = await mediator.Send(query);
        return Ok(posts);
    }
}
