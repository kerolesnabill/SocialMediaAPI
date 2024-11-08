using Microsoft.EntityFrameworkCore;
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

    public async Task Delete(Post entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<(IEnumerable<Post>, int)> GetAllAsync(int pageSize, int pageNumber, string? searchPhase)
    {
        searchPhase = searchPhase?.ToLower();

        var baseQuery = dbContext.Posts
            .Where(p => searchPhase == null ||
                   (p.Content.Title != null && p.Content.Title.ToLower().Contains(searchPhase)) ||
                   (p.Content.Description != null && p.Content.Description.ToLower().Contains(searchPhase)));

        var totalCount = await baseQuery.CountAsync();

        var posts = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (posts, totalCount);
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        var post = await dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
        return post;
    }

    public async Task UpdateAsync(Post post)
    {
        dbContext.Update(post);
        await dbContext.SaveChangesAsync();
    }
}
