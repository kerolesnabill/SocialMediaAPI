﻿using SocialMediaDomain.Entities;

namespace SocialMediaDomain.Interfaces;

public interface IUsersRepository
{
    Task<(IEnumerable<User>, int)> GetAllAsync(int pageSize, int pageNumber);
    Task<User?> GetByIdWithFollowingAsync(string id);
    Task<User?> GetByIdWithFollowersAsync(string id);
    Task<(int, int)> GetFollowersAndFollowingCountAsync(string id);
    Task<User?> GetByIdWithPostsAsync(string id);
    Task FollowAsync(User follower, User following);
    Task UnfollowAsync(User follower, User following);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task<IEnumerable<User>> FindManyContains(string searchPhase);
}
