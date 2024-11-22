using FluentValidation.TestHelper;
using SocialMediaApplication.Posts.Commands.CreatePost;
using Xunit;

namespace SocialMediaApplicationTests.Posts.Commands.CreatePost;

public class CreatePostCommandValidatorTests
{
    [Fact()]
    public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
    {
        var command = new CreatePostCommand(){ Content = "Post Content"};
        var validator = new CreatePostCommandValidator();

        var result = validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory()]
    [InlineData("")]
    [InlineData("  ")]
    public void Validator_ForInvalidCommand_ShouldHaveValidationErrors(string content)
    {
        var command = new CreatePostCommand() { Content = content };
        var validator = new CreatePostCommandValidator();

        var result = validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(p => p.Content);
    }
}