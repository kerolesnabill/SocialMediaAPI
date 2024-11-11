using MediatR;
using SocialMediaApplication.Users.Dtos;

namespace SocialMediaApplication.Users.Queries.GetUserById;

public class GetUserByIdQuery(string id) : IRequest<UserDto>
{
    public string Id { get; set; } = id;
}
