using Microsoft.EntityFrameworkCore;
using SocialMediaDomain.Entities;

namespace SocialMediaInfrastructure.Persistence;

internal class SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : DbContext(options)
{
    internal DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
