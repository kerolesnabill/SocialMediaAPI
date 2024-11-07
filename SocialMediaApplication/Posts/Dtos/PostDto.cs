using SocialMediaDomain.Entities;

namespace SocialMediaApplication.Posts.Dtos;

public class PostDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public IEnumerable<string>? Images { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }


    public User Author { get; set; } = default!;
    public string AuthorId { get; set; } = default!;
}
