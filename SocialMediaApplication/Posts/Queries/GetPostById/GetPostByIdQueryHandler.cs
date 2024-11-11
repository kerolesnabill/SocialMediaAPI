using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Posts.Dtos;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Posts.Queries.GetPostById;

public class GetPostByIdQueryHandler(ILogger<GetPostByIdQueryHandler> logger,
        IPostsRepository postsRepository,
        IMapper mapper) : IRequestHandler<GetPostByIdQuery, PostDto>
{
    public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting post with Id: {PostId}", request.Id);

        var post = await postsRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Post), request.Id.ToString());

        var result = mapper.Map<PostDto>(post);
        result.LikesCount = await postsRepository.GetLikesCountAsync(request.Id);

        return result;
    }
}
