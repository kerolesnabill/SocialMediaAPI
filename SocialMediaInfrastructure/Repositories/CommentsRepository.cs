using Microsoft.EntityFrameworkCore;
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

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await dbContext.Comments.Include(c => c.Commenter).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Comment?> GetByIdWithLikesAsync(int id)
    {
        return await dbContext.Comments.Include(c => c.Likes).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<int> GetLikesCountAsync(int id)
    {
        return await dbContext.Comments.
            Where(c => c.Id == id)
            .Select(c => c.Likes.Count)
            .FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Comment entity)
    {
        dbContext.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddLikeAsync(Comment comment, User user)
    {
        comment.Likes.Add(user);
        await dbContext.SaveChangesAsync(); 
    }

    public async Task RemoveLikeAsync(Comment comment, User user)
    {
        comment.Likes.Remove(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Comment entity)
    {
        entity.Likes = [];
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}
