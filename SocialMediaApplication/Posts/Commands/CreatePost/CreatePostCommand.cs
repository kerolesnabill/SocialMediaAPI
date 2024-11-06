﻿using MediatR;

namespace SocialMediaApplication.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<int>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public IEnumerable<string>? Images { get; set; }
}
