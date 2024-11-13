using SocialMediaDomain.Entities;
using SocialMediaDomain.Interfaces;
using SocialMediaInfrastructure.Persistence;

namespace SocialMediaInfrastructure.Repositories;

internal class CommentsRepository(SocialMediaDbContext dbContext) : ICommentsRepository
{
    public async Task<int> Create(Comment entity)
    {
        dbContext.Comments.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
}
