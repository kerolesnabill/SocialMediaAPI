using Microsoft.EntityFrameworkCore;
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
    
    public async Task UnfollowAsync(User follower, User following)
    {
        follower.Following.Remove(following);
        await dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetByIdWithFollowingAsync(string id)
    {
        var user = await dbContext.Users.Include(u => u.Following).FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<User?> GetByIdWithFollowersAsync(string id)
    {
        var user = await dbContext.Users.Include(u => u.Followers).FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<(int, int)> GetFollowersAndFollowingCountAsync(string id)
    {
        var user = await dbContext.Users.Where(u => u.Id == id)
                    .Select(u => new
                    {
                        FollowersCount = u.Followers.Count,
                        FollowingCount = u.Following.Count
                    }).FirstOrDefaultAsync();

        return (user!.FollowersCount, user.FollowingCount);
    }

    public async Task<User?> GetByIdWithPostsAsync(string id)
    {
        var user = await dbContext.Users.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }
}
