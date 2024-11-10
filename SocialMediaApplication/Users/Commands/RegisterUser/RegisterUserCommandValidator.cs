using FluentValidation;

namespace SocialMediaApplication.Users.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.FullName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(u => u.Username)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
