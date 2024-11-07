using Microsoft.AspNetCore.Http;
using Moq;
using SocialMediaApplication.Users;
using System.Security.Claims;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialMediaApplication.Users;

public class UserContextTests
{
    [Fact()]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
    {
        var httpContextAccessor =  new Mock<IHttpContextAccessor>();
        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, "1"),
            new(ClaimTypes.Name, "username"),
            new(ClaimTypes.Email, "test@test.com"),
        };
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));
        httpContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
        {
            User = user
        });
        var userContext = new UserContext(httpContextAccessor.Object);

        var currentUser = userContext.GetCurrentUser();

        Assert.NotNull(currentUser);
        Assert.Equal("1", currentUser.Id);
        Assert.Equal("username", currentUser.Username);
        Assert.Equal("test@test.com", currentUser.Email);
    }

    [Fact()]
    public void GetCurrentUser_WithUserContextNotPresent_ThrowsInvalidOperationException()
    {
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        httpContextAccessor.Setup(x => x.HttpContext).Returns(null as HttpContext);
        var userContext = new UserContext(httpContextAccessor.Object);

        Action action = () => userContext.GetCurrentUser();

        Assert.Throws<InvalidOperationException>(() => action());
    }
}