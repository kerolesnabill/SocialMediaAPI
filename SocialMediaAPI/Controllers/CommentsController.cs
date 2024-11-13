using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApplication.Comments.Commands.CreateComment;
using SocialMediaApplication.Comments.Commands.UpdateComment;
using SocialMediaApplication.Comments.Queries.GetCommentById;

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
        var commentId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetCommentById), new {postId, commentId}, null);
    }

    [HttpGet("{commentId}")]
    public async Task<IActionResult> GetCommentById([FromRoute] GetCommentByIdQuery command)
    {
        var comment = await mediator.Send(command);
        return Ok(comment);
    }


    [HttpPatch("{commentId}")]
    public async Task<IActionResult> UpdateComment([FromRoute] int commentId, [FromRoute] int postId, [FromBody] UpdateCommentCommand command)
    {
        command.Id = commentId;
        command.PostId = postId;
        await mediator.Send(command);
        return NoContent();
    }
}
