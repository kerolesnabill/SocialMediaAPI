using MediatR;
using SocialMediaApplication.Posts.Dtos;

namespace SocialMediaApplication.Posts.Queries.GetAllPosts;

public class GetAllPostsQuery : IRequest<IEnumerable<PostDto>>
{
}
