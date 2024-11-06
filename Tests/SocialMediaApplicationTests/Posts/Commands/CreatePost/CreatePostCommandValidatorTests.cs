using FluentValidation.TestHelper;
using SocialMediaApplication.Posts.Commands.CreatePost;
using Xunit;

namespace SocialMediaApplicationTests.Posts.Commands.CreatePost;

public class CreatePostCommandValidatorTests
{
    [Theory()]
    [InlineData("title", "description")]
    [InlineData("title", null)]
    [InlineData(null, "description")]
    public void Validator_ForValidCommand_ShouldNotHaveValidationErrors(string? title, string? description)
    {
        var command = new CreatePostCommand()
        {
            Title = title,
            Description = description,
        };
        var validator = new CreatePostCommandValidator();

        var result = validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory()]
    [InlineData("", "")]
    [InlineData("  ", "  ")]
    public void Validator_ForInvalidCommand_ShouldHaveValidationErrors(string? title, string? description)
    {
        var command = new CreatePostCommand()
        {
            Title = title,
            Description = description,
        };
        var validator = new CreatePostCommandValidator();

        var result = validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(p => p.Title);
        result.ShouldHaveValidationErrorFor(p => p.Description);
        result.ShouldHaveValidationErrorFor(p => p);
    }
}