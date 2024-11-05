using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;
using SocialMediaInfrastructure.Persistence;

namespace SocialMediaInfrastructure.Repositories;

internal class PostsRepository(SocialMediaDbContext dbContext) : IPostsRepository
{
    public async Task<int> Create(Post entity)
    {
        dbContext.Posts.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
}
