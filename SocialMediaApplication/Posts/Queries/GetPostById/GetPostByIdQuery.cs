using MediatR;
using SocialMediaApplication.Posts.Dtos;

namespace SocialMediaApplication.Posts.Queries.GetPostById;

public class GetPostByIdQuery(int id) : IRequest<PostDto>
{
    public int Id { get; set; } = id;
}
