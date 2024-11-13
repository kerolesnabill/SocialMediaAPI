using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApplication.Comments.CreateComment;

namespace SocialMediaAPI.Controllers;

[Route("api/posts/{postId}/comments")]
[ApiController]
[Authorize]
public class CommentsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateComment([FromRoute] int postId, CreateCommentCommand command)
    {
        command.PostId = postId;
        var id = await mediator.Send(command);
        return Created();
    }
}
