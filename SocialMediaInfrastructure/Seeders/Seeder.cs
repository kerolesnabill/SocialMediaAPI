using Microsoft.AspNetCore.Identity;
using SocialMediaDomain.Constants;
using SocialMediaInfrastructure.Persistence;

namespace SocialMediaInfrastructure.Seeders;

internal class Seeder(SocialMediaDbContext dbContext) : ISeeder
{
    public async Task Seed()
    {
        if (dbContext.Database.CanConnect())
        {
            if (!dbContext.Roles.Any())
            {
                dbContext.AddRange(GetRoles());
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        return 
            [
                new IdentityRole(UserRoles.User) {NormalizedName = UserRoles.User.ToUpper()},
                new IdentityRole(UserRoles.Admin) {NormalizedName = UserRoles.Admin.ToUpper()},
            ];
    }
}
