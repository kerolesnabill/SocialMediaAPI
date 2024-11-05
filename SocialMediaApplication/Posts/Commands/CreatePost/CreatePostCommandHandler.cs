using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Posts.Commands.CreatePost;

public class CreatePostCommandHandler(ILogger<CreatePostCommandHandler> logger, 
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

        var postId = await postsRepository.Create(post);
        return postId;
    }
}
