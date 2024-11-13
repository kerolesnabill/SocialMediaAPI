using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Comments.Commands.LikeOrUnlikeComment;

public class LikeOrUnlikeCommentCommandHandler(ILogger<LikeOrUnlikeCommentCommandHandler> logger,
        IPostsRepository postsRepository,
        ICommentsRepository commentsRepository,
        UserManager<User> userManager,
        IUserContext userContext) : IRequestHandler<LikeOrUnlikeCommentCommand>
{
    public async Task Handle(LikeOrUnlikeCommentCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("Like/Unlike comment: {CommentId}, post: {PostId}, by user: {UserId}",
            request.CommentId, request.PostId, currentUser!.Id);

        var user = await userManager.FindByIdAsync(currentUser.Id)
             ?? throw new NotFoundException(nameof(User), currentUser.Id);

        var post = await postsRepository.GetByIdAsync(request.PostId)
            ?? throw new NotFoundException(nameof(Post), request.PostId.ToString());

        var comment = await commentsRepository.GetByIdWithLikesAsync(request.CommentId)
            ?? throw new NotFoundException(nameof(Comment), request.CommentId.ToString());

        if (comment.Likes.Contains(user))
            await commentsRepository.RemoveLikeAsync(comment, user);
        else
            await commentsRepository.AddLikeAsync(comment, user);
    }
}
