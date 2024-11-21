﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;
using SocialMediaDomain.Exceptions;
using Xunit;
using Assert = Xunit.Assert;
using SocialMediaApplication.Posts.Queries.GetPostById;
using SocialMediaApplication.Posts.Dtos;

namespace SocialMediaApplicationTests.Posts.Queries.GetPostById;

public class GetPostByIdQueryHandlerTests
{
    private readonly Mock<ILogger<GetPostByIdQueryHandler>> _logger;
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IPostsRepository> _postsRepository;
    private readonly GetPostByIdQueryHandler _handler;

    public GetPostByIdQueryHandlerTests()
    {
        _logger = new Mock<ILogger<GetPostByIdQueryHandler>>();
        _mapper = new Mock<IMapper>();
        _postsRepository = new Mock<IPostsRepository>();

        _handler = new GetPostByIdQueryHandler
            (_logger.Object, _postsRepository.Object, _mapper.Object);
    }


    [Fact()]
    public async void Handle_WithValidQuery_ReturnPostDto()
    {
        var id = 1000;
        var post = new Post() { Id =  id};
        var postDto = new PostDto() { Id = id};

        _mapper.Setup(m => m.Map<PostDto>(post)).Returns(postDto);
        _postsRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(post);

        var query = new GetPostByIdQuery(id);
        var result = await _handler.Handle(query, CancellationToken.None);
        
        Assert.NotNull(result);
        Assert.Equal(postDto, result);
        _postsRepository.Verify(r => r.GetByIdAsync(id), Times.Once());
    }

    [Fact()]
    public async Task Handle_WithNonExistingPost_ThrowsNotFoundException()
    {
        var id = 1;
        var post = new Post() { Id = id};

        _postsRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(null as Post);

        var query = new GetPostByIdQuery(id);
        Func<Task> act = async () => await _handler.Handle(query, CancellationToken.None);

        await Assert.ThrowsAsync<NotFoundException>(act);     
    }
}