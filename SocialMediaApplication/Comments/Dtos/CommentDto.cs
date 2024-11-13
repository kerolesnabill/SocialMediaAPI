using SocialMediaApplication.Users.Dtos;

namespace SocialMediaApplication.Comments.Dtos;

public class CommentDto
{
    public int Id { get; set; }
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public UserMiniDto Commenter { get; set; } = default!;

    public int LikesCount { get; set; }
}
