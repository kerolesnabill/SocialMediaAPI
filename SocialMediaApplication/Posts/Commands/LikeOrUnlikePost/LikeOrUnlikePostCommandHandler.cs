using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Posts.Commands.LikeOrUnlikePost;

public class LikeOrUnlikePostCommandHandler(ILogger<LikeOrUnlikePostCommandHandler> logger,
        IPostsRepository postsRepository,
        UserManager<User> userManager,
        IUserContext userContext) : IRequestHandler<LikeOrUnlikePostCommand>
{
    public async Task Handle(LikeOrUnlikePostCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("Like/Unlike post: {PostId}, by user: {UserId}", request.Id, currentUser!.Id);

        var user = await userManager.FindByIdAsync(currentUser.Id)
            ?? throw new NotFoundException(nameof(User), currentUser.Id);

        var post = await postsRepository.GetByIdWithLikesAsync(request.Id)
            ?? throw new NotFoundException(nameof(Post), request.Id.ToString());

        if (post.Likes.Contains(user))
            await postsRepository.RemoveLikeAsync(post, user);
        else
            await postsRepository.AddLikeAsync(post, user);
    }
}
