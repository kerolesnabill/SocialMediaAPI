using SocialMediaDomain.Entities;

namespace SocialMediaDomain.Interfaces;

public interface ICommentsRepository
{
    Task<int> Create(Comment entity);
    Task<Comment?> GetByIdAsync(int id);
    Task<int> GetLikesCountAsync(int id);
}
