using SocialMediaDomain.Constants;
using SocialMediaDomain.Entities;

namespace SocialMediaDomain.Interfaces;

public interface ICommentAuthorizationService
{
    bool Authorize(Comment comment, Post post, ResourceOperation resourceOperation);
}
