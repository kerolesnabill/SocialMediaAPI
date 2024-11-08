using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Posts.Dtos;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Posts.Queries.GetAllPosts;

public class GetAllPostsQueryHandler(ILogger<GetAllPostsQueryHandler> logger,
        IPostsRepository postsRepository,
        IMapper mapper) : IRequestHandler<GetAllPostsQuery, IEnumerable<PostDto>>
{
    public async Task<IEnumerable<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all posts");
        var posts = await postsRepository.GetAllAsync();

        var result = mapper.Map<IEnumerable<PostDto>>(posts);
        return result;
    }
}
