using MediatR;

namespace SocialMediaApplication.Posts.Commands.DeletePost;

public class DeletePostCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
