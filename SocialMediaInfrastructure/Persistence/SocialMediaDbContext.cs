using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaDomain.Entities;

namespace SocialMediaInfrastructure.Persistence;

internal class SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) 
        : IdentityDbContext<User>(options)
{
    internal DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Post>()
            .OwnsOne(p => p.Content);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Followers)
            .WithMany(u => u.Following)
            .UsingEntity<Dictionary<string, object>>(
                "UserFollowers",
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("FollowerId")
                    .OnDelete(DeleteBehavior.NoAction),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("FollowingId")
                    .OnDelete(DeleteBehavior.NoAction));

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Likes)
            .WithMany(u => u.LikedPosts)
            .UsingEntity<Dictionary<string, object>>(
                "PostLikes", 
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.NoAction),
                j => j
                    .HasOne<Post>()
                    .WithMany()
                    .HasForeignKey("PostId")
                    .OnDelete(DeleteBehavior.NoAction));
    }
}
