using SocialMediaAPI.Middlewares;
using SocialMediaDomain.Entities;
using SocialMediaInfrastructure.Persistence;

namespace SocialMediaAPI.Extensions;

public static class WebApplicationBuilderExtension
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<SocialMediaDbContext>();

        builder.Services.AddScoped<ErrorHandlingMiddleware>();
    }
}
