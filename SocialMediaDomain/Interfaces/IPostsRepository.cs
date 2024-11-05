using SocialMediaDomain.Entities;

namespace SocialMediaDomain.Interfaces;

public interface IPostsRepository
{
    Task<int> Create(Post entity);
}
