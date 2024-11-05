using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaInfrastructure.Persistence;

namespace SocialMediaInfrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SocialMediaDb");
        services.AddDbContext<SocialMediaDbContext>(
            options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
    }
}
