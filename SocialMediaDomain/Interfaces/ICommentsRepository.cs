using SocialMediaDomain.Entities;

namespace SocialMediaDomain.Interfaces;

public interface ICommentsRepository
{
    Task<int> Create(Comment entity);
    Task<Comment?> GetByIdAsync(int id);
    Task<Comment?> GetByIdWithLikesAsync(int id);
    Task<int> GetLikesCountAsync(int id);
    Task UpdateAsync(Comment entity);
    Task AddLikeAsync(Comment comment, User user);
    Task RemoveLikeAsync(Comment comment, User user);
}
