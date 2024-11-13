using SocialMediaDomain.Entities;

namespace SocialMediaDomain.Interfaces;

public interface ICommentsRepository
{
    Task<int> Create(Comment entity);
}
