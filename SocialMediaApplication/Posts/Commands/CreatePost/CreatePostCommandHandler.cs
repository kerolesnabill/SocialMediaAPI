using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Posts.Commands.CreatePost;

public class CreatePostCommandHandler(ILogger<CreatePostCommandHandler> logger, 
        IPostsRepository postsRepository, IMapper mapper) : IRequestHandler<CreatePostCommand, int>
{
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var authorId = "2bd04a62-da09-4dc7-9dc3-76e856ae253c"; // I will edit it later
        logger.LogInformation("User {UserId} creating new post {Post}", authorId, request);

        var post = mapper.Map<Post>(request);
        post.AuthorId = authorId;
        post.CreatedAt = DateTime.Now;

        var postId = await postsRepository.Create(post);
        return postId;
    }
}
