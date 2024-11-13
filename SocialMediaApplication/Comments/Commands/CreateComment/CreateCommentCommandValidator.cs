using FluentValidation;

namespace SocialMediaApplication.Comments.Commands.CreateComment;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(c => c.Content)
            .NotEmpty();
    }
}
