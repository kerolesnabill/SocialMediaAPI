namespace SocialMediaApplication.Users.Dtos;

public class UserMiniDto
{
    public string Id { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string? Picture { get; set; }
}
