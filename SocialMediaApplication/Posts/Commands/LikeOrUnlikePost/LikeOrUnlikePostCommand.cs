using MediatR;

namespace SocialMediaApplication.Posts.Commands.LikeOrUnlikePost;

public class LikeOrUnlikePostCommand(int postId) : IRequest
{
    public int Id { get; set; } = postId;
}
