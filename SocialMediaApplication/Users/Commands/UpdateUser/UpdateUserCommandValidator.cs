using FluentValidation;

namespace SocialMediaApplication.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty()
            .MaximumLength(50)
            .When(c => c.FullName != null);

        RuleFor(c => c.Bio)
            .MaximumLength(150)
            .When(c => c.Bio != null);
    }
}
