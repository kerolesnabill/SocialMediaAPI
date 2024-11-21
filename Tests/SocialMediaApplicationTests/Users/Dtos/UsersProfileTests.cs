using AutoMapper;
using SocialMediaApplication.Users.Commands.UpdateUser;
using SocialMediaApplication.Users.Dtos;
using SocialMediaDomain.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaApplicationTests.Users.Dtos;

public class UsersProfileTests
{
    private IMapper _mapper;

    public UsersProfileTests()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<UsersProfile>());
        _mapper = configuration.CreateMapper();
    }

    [Fact()]
    public void CreateMap_ForUserToUserDto_MapsCorrectly()
    {
        var user = new User()
        {
            Id = "std-55363",
            UserName = "Test",
            FullName = "Test Test",
            Bio = "bio .. ..",
            Picture = "image.jpg"
        };

        var result = _mapper.Map<UserDto>(user);

        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);
        Assert.Equal(user.UserName, result.Username);
        Assert.Equal(user.FullName, result.FullName);
        Assert.Equal(user.Bio, result.Bio);
        Assert.Equal(user.Picture, result.Picture);
    }

    [Fact()]
    public void CreateMap_ForUserToUserMiniDto_MapsCorrectly()
    {
        var user = new User()
        {
            Id = "std-55363",
            UserName = "Test",
            FullName = "Test Test",
            Bio = "bio .. ..",
            Picture = "image.jpg"
        };

        var result = _mapper.Map<UserMiniDto>(user);

        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);
        Assert.Equal(user.UserName, result.Username);
        Assert.Equal(user.FullName, result.FullName);
        Assert.Equal(user.Picture, result.Picture);
    }

    [Fact()]
    public void CreateMap_ForUpdateUserCommandToUser_MapsCorrectly()
    {
        var user = new UpdateUserCommand()
        {
            FullName = "Test Test",
            Bio = "bio .. ..",
            Picture = "image.jpg"
        };

        var result = _mapper.Map<User>(user);

        Assert.NotNull(result);
        Assert.Equal(user.FullName, result.FullName);
        Assert.Equal(user.Bio, result.Bio);
        Assert.Equal(user.Picture, result.Picture);
    }
}
