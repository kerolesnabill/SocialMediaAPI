namespace SocialMediaApplication.Posts.Dtos;

public class PostDto
{
    public int Id { get; set; }
    public string Content { get; set; } = default!;
    public IEnumerable<string>? Images { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public int LikesCount { get; set; }

    public string AuthorId { get; set; } = default!;
}
