using MediatR;
using SocialMediaApplication.Common;
using SocialMediaApplication.Users.Dtos;

namespace SocialMediaApplication.Users.Commands.GetAllUsers;

public class GetAllUsersQuery : IRequest<PagedResult<UserMiniDto>>
{
    public int PageSize { get; set; } = 50;
    public int PageNumber { get; set; } = 1;

}
