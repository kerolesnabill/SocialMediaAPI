﻿using MediatR;
using SocialMediaApplication.Common;
using SocialMediaApplication.Posts.Dtos;

namespace SocialMediaApplication.Posts.Queries.GetFeed;

public class GetFeedQuery : IRequest<PagedResult<PostDto>>
{
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
    public string? searchPhase { get; set; }
}