using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApplication.Users.Commands.AssignUserRole;
using SocialMediaApplication.Users.Commands.UnassignUserRole;
using SocialMediaDomain.Constants;

namespace SocialMediaAPI.Controllers;

[Route("api/admin")]
[ApiController]
[Authorize(Roles = UserRoles.Admin)]
public class AdminController(IMediator mediator) : ControllerBase
{
    [HttpPost("userRole")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("userRole")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UnassignUserRole(UnassignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}
