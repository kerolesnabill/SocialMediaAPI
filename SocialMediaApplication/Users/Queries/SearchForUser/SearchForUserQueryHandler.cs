﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SocialMediaApplication.Users.Dtos;
using SocialMediaDomain.Interfaces;

namespace SocialMediaApplication.Users.Queries.SearchForUser;

public class SearchForUserQueryHandler(ILogger<SearchForUserQueryHandler> logger,
        IUsersRepository usersRepository,
        IMapper mapper) : IRequestHandler<SearchForUserQuery, IEnumerable<UserMiniDto>>
{
    public async Task<IEnumerable<UserMiniDto>> Handle(SearchForUserQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Search for `{SearchPhase}` on users", request.SearchPhase);

        var users = await usersRepository.FindManyContains(request.SearchPhase);

        return mapper.Map<IEnumerable<UserMiniDto>>(users);
    }
}
