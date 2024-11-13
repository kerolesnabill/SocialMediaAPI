namespace SocialMediaDomain.Entities;

public class Post
{
    public int Id { get; set; }
    public PostContent Content { get; set; } = default!;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User Author { get; set; } = default!;
    public string AuthorId { get; set; } = default!;

    public ICollection<User> Likes { get; set; } = [];

    public ICollection<Comment> Comments { get; set; } = [];
}
