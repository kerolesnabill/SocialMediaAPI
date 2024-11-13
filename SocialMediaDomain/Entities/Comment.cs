namespace SocialMediaDomain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; } = default!;

    public string CommenterId { get; set; } = default!;
    public User Commenter { get; set; } = default!;

    public ICollection<User> Likes { get; set; } = [];
}
