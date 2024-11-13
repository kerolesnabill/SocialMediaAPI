﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Comments.Commands.CreateComment;

public class CreateCommentCommandHandler(ILogger<CreateCommentCommandHandler> logger,
        ICommentsRepository commentsRepository,
        IPostsRepository postsRepository,
        IUserContext userContext,
        IMapper mapper) : IRequestHandler<CreateCommentCommand, int>
{
    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("Create comment: {@Comment}, for post: {PostId}, by user: {UserId}",
                request.Content, request.PostId, user!.Id);

        var post = await postsRepository.GetByIdAsync(request.PostId)
            ?? throw new NotFoundException(nameof(Post), request.PostId.ToString());

        var comment = mapper.Map<Comment>(request);
        comment.CommenterId = user.Id;
        comment.CreatedAt = DateTime.Now;

        return await commentsRepository.Create(comment);
    }
}
