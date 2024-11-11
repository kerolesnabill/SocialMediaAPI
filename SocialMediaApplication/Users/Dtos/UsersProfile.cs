using AutoMapper;
using SocialMediaApplication.Users.Commands.UpdateUser;
using SocialMediaDomain.Entities;

namespace SocialMediaApplication.Users.Dtos;

internal class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, UserMiniDto>();
        CreateMap<User, UserDto>();
        CreateMap<UpdateUserCommand, User>()
            .ForAllMembers(options => 
                options.Condition((src, dest, srcMember) => srcMember != null));
    }
}
