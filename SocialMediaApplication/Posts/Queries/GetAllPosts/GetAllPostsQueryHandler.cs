using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Common;
using SocialMediaApplication.Posts.Dtos;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Posts.Queries.GetAllPosts;

public class GetAllPostsQueryHandler(ILogger<GetAllPostsQueryHandler> logger,
        IPostsRepository postsRepository,
        IMapper mapper) : IRequestHandler<GetAllPostsQuery, PagedResult<PostDto>>
{
    public async Task<PagedResult<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting posts in page: {PageNumber}", request.PageNumber);
        var (posts, totalCount) = await postsRepository
            .GetAllAsync(request.PageSize, request.PageNumber, request.searchPhase);

        var postDtos = mapper.Map<IEnumerable<PostDto>>(posts);

        var result = new PagedResult<PostDto>(postDtos, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}
