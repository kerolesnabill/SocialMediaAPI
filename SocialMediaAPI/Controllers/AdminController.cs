using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApplication.Users.Commands.AssignUserRole;
using SocialMediaApplication.Users.Commands.DeleteUserByAdmin;
using SocialMediaApplication.Users.Commands.GetAllUsers;
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

    [HttpGet("users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQuery query)
    {
        var users = await mediator.Send(query);
        return Ok(users);
    }


    [HttpDelete("users/{userId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUser ([FromRoute] DeleteUserByAdminCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

}
