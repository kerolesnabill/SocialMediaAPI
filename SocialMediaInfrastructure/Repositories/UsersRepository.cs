﻿using Microsoft.EntityFrameworkCore;
using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;
using SocialMediaInfrastructure.Persistence;

namespace SocialMediaInfrastructure.Repositories;

internal class UsersRepository(SocialMediaDbContext dbContext) : IUsersRepository
{
    public async Task FollowAsync(User follower, User following)
    {
        follower.Following.Add(following);
        await dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetByIdWithFollowingAsync(string id)
    {
        var user = await dbContext.Users.Include(u => u.Following).FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }
}
