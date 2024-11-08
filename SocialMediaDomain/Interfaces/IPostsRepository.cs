using SocialMediaDomain.Entities;

namespace SocialMediaDomain.Interfaces;

public interface IPostsRepository
{
    Task<int> Create(Post entity);
    Task<Post?> GetByIdAsync(int id);
    Task Delete(Post entity);
    Task UpdateAsync(Post post);
    Task<IEnumerable<Post>> GetAllAsync();
}
