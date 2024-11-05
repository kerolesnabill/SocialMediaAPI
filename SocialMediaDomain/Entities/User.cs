using Microsoft.AspNetCore.Identity;

namespace SocialMediaDomain.Entities;

public class User : IdentityUser
{
    public IEnumerable<Post> Posts { get; set; } = [];
}
