using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApplication.Users.Commands.FollowUser;
using SocialMediaApplication.Users.Commands.RegisterUser;
using SocialMediaApplication.Users.Commands.UnfollowUser;

namespace SocialMediaAPI.Controllers;

[Route("api/users")]
[ApiController]
[Authorize]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost("register", Order = -1)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await mediator.Send(command);
        if(result.Succeeded)
            return Ok();

        return BadRequest(result.Errors);
    }

    [HttpPost("{id}/follow")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Follow([FromRoute] string id)
    {
        await mediator.Send(new FollowUserCommand(id));
        return Ok();
    }

    [HttpDelete("{id}/unfollow")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Unfollow([FromRoute] string id)
    {
        await mediator.Send(new UnfollowUserCommand(id));
        return NoContent();
    }
}
