using FluentValidation;

namespace SocialMediaApplication.Comments.CreateComment;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(c => c.Content)
            .NotEmpty();
    }
}
