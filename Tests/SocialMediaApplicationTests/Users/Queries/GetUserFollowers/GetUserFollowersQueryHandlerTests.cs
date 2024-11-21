﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SocialMediaApplication.Users.Dtos;
using SocialMediaApplication.Users.Queries.GetUserFollowers;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaApplicationTests.Users.Queries.GetUserFollowers
{
    public class GetUserFollowersQueryHandlerTests
    {
        private Mock<ILogger<GetUserFollowersQueryHandler>> _logger = new();
        private Mock<IUsersRepository> _usersRepository = new();
        private Mock<IMapper> _mapper = new();
        private GetUserFollowersQueryHandler _handler;

        public GetUserFollowersQueryHandlerTests()
        {
            _handler = new(_logger.Object, _usersRepository.Object, _mapper.Object);
        }

        [Fact()]
        public async void Handle_WithValidQuery_GetFollowersList()
        {
            string id = "userId";
            List<User> followers = [new() { Id = "user1" }, new() { Id = "user2" }];
            List<UserMiniDto> followersDto = [new() { Id = "user1" }, new() { Id = "user2" }];
            User user = new() { Id = id, Followers = followers};

            _usersRepository.Setup(r => r.GetByIdWithFollowersAsync(id)).ReturnsAsync(user);
            _mapper.Setup( m => m.Map<IEnumerable<UserMiniDto>>(followers)).Returns(followersDto);

            var result = await _handler.Handle(new(id), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(followersDto, result);
            _usersRepository.Verify(r => r.GetByIdWithFollowersAsync(id), Times.Once);
        }
    }
}