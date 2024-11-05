using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users;
using SocialMediaDomain.Constants;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Posts.Commands.CreatePost;

public class CreatePostCommandHandler(ILogger<CreatePostCommandHandler> logger, 
        IPostAuthorizationService postAuthorizationService,
        IPostsRepository postsRepository, 
        IUserContext userContext,
        IMapper mapper) : IRequestHandler<CreatePostCommand, int>
{
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("User {UserId} creating new post {@Post}", user!.Id, request);

        var post = mapper.Map<Post>(request);
        post.AuthorId = user.Id;
        post.CreatedAt = DateTime.Now;

        bool isAuthorized = postAuthorizationService.Authorize(post, ResourceOperation.Create);
        if (!isAuthorized)
            throw new Exception(); // I will edit it later

        var postId = await postsRepository.Create(post);
        return postId;
    }
}
