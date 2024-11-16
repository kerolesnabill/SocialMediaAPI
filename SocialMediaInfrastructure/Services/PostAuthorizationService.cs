using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users;
using SocialMediaDomain.Constants;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;

namespace SocialMediaInfrastructure.Services;

internal class PostAuthorizationService(ILogger<PostAuthorizationService> logger,
        IUserContext userContext) : IPostAuthorizationService
{
    public bool Authorize(Post post, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser();

        logger.LogInformation("Authorize user {UserId}, to {Operation} for post {Post}", user!.Id, resourceOperation, post.Id);

        if (resourceOperation == ResourceOperation.Create ||  resourceOperation == ResourceOperation.Read)
        {
            logger.LogInformation("Create/Read operation - successful authorization");
            return true;
        }

        if (resourceOperation == ResourceOperation.Update && user.Id == post.AuthorId)
        {
            logger.LogInformation("Post author - successful authorization");
            return true;
        }

        if (resourceOperation == ResourceOperation.Delete &&
            (user.Id == post.AuthorId || user.IsInRole(UserRoles.Admin))) 
        {
            logger.LogInformation("Delete operation- successful authorization");
            return true;
        }

        return false;
    }
}
