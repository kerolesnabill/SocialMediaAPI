﻿using Microsoft.AspNetCore.Identity;

namespace SocialMediaDomain.Entities;

public class User : IdentityUser
{
    public string FullName { get; set; } = default!;
    public string? Bio { get; set; }
    public string? Picture { get; set; }
    public DateTime? CreatedAt { get; set; }

    public ICollection<User> Followers { get; set; } = [];
    public ICollection<User> Following { get; set; } = [];

    public ICollection<Post> Posts { get; set; } = [];
    public ICollection<Post> LikedPosts { get; set; } = [];

    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Comment> LikedComments { get; set; } = [];
}
