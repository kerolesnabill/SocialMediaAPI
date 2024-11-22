using FluentValidation;

namespace SocialMediaApplication.Posts.Commands.UpdatePost;

public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(p => p.Content)
            .NotEmpty()
            .When(p => p.Content != null);
    }
}
