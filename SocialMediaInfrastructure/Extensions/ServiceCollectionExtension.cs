using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaDomain.Interfaces;
using SocialMediaInfrastructure.Persistence;
using SocialMediaInfrastructure.Repositories;

namespace SocialMediaInfrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SocialMediaDb");
        services.AddDbContext<SocialMediaDbContext>(
            options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

        services.AddScoped<IPostsRepository, PostsRepository>();
    }
}
