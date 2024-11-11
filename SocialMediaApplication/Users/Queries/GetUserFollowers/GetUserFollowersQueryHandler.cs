﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users.Dtos;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Exceptions;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Users.Queries.GetUserFollowers;

public class GetUserFollowersQueryHandler(ILogger<GetUserFollowersQueryHandler> logger,
        IUsersRepository usersRepository,
        IMapper mapper) : IRequestHandler<GetUserFollowersQuery, IEnumerable<UserMiniDto>>
{
    public async Task<IEnumerable<UserMiniDto>> Handle(GetUserFollowersQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting followers for user: {UserId}", request.Id);

        var user = await usersRepository.GetByIdWithFollowersAsync(request.Id)
            ?? throw new NotFoundException(nameof(User), request.Id);

        var result = mapper.Map<IEnumerable<UserMiniDto>>(user.Followers);
        return result;
    }
}
