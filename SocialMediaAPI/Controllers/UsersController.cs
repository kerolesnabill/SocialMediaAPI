using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApplication.Users.Commands.RegisterUser;

namespace SocialMediaAPI.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost("register", Order = -1)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await mediator.Send(command);
        if(result.Succeeded)
            return Ok();

        return BadRequest(result.Errors);
    }
}
