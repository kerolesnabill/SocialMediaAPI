using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaApplication.Users;

namespace SocialMediaApplication.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddAutoMapper(applicationAssembly);

        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();
    }
}
