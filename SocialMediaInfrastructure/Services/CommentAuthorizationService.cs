using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users;
using SocialMediaDomain.Constants;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;

namespace SocialMediaInfrastructure.Services;

internal class CommentAuthorizationService(ILogger<PostAuthorizationService> logger,
        IUserContext userContext) : ICommentAuthorizationService
{
    public bool Authorize(Comment comment, Post post, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser();

        logger.LogInformation("Authorize user {UserId}, to {Operation} for comment {Comment}", user!.Id, resourceOperation, comment.Id);

        if (resourceOperation == ResourceOperation.Create || resourceOperation == ResourceOperation.Read)
        {
            logger.LogInformation("Create/Read operation - successful authorization");
            return true;
        }

        if (resourceOperation == ResourceOperation.Delete && 
            (user.Id == comment.CommenterId || user.Id == post.AuthorId))
        {
            logger.LogInformation("Commenter/Post author - Delete operation - successful authorization");
            return true;
        }

        if (resourceOperation == ResourceOperation.Update && user.Id == comment.CommenterId)
        {
            logger.LogInformation("Commenter - successful authorization");
            return true;
        }

        return false;
    }
}
