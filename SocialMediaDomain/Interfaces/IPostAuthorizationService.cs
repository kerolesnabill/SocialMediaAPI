using SocialMediaDomain.Constants;
using SocialMediaDomain.Entities;

namespace SocialMediaDomain.Interfaces;

public interface IPostAuthorizationService
{
    bool Authorize(Post post, ResourceOperation resourceOperation);
}
