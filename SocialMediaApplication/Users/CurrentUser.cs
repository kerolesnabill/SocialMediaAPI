namespace SocialMediaApplication.Users;

public record CurrentUser(string Id, string Email, string Username, IEnumerable<string> Roles)
{
    public bool IsInRole(string role) => Roles.Contains(role);
}
