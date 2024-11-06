namespace SocialMediaDomain.Entities;

public class PostContent
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public IEnumerable<string>? Images { get; set; }
}
