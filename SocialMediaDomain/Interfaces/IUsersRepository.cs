using SocialMediaDomain.Entities;

namespace SocialMediaDomain.Interfaces;

public interface IUsersRepository
{
    Task<User?> GetByIdWithFollowingAsync(string id);
    Task FollowAsync(User follower, User following);
    Task UnfollowAsync(User follower, User following);
}
