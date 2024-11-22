﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users;
using SocialMediaDomain.Constants;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Posts.Commands.CreatePost;

public class CreatePostCommandHandler(ILogger<CreatePostCommandHandler> logger, 
        IPostAuthorizationService postAuthorizationService,
        IBlobStorageService blobStorageService,
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
            throw new ForbidException();

        if(request.Images != null && request.Images.Count > 0)
        {
            post.Images = [];
            int x = DateTime.Now.GetHashCode();

            foreach (var image in request.Images)
            {
                string filename = $"post-user-{user.Id}-{x++}.jpeg";
                var stream = image.OpenReadStream();

                string imageUrl = await blobStorageService.UploadToBlobAsync
                    (stream, filename, ContainerName.PostsContainerName);
                post.Images.Add(imageUrl);
            }
        }

        var postId = await postsRepository.Create(post);
        return postId;
    }
}
