using AutoMapper;
using SocialMediaDomain.Entities;

namespace SocialMediaApplication.Users.Dtos;

internal class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, UserMiniDto>();
    }
}
