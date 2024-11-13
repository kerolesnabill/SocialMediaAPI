using FluentValidation;
using SocialMediaApplication.Comments.Commands.CreateComment;

namespace SocialMediaApplication.Comments.Commands.UpdateComment;

public class UpdateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        RuleFor(c => c.Content)
            .NotEmpty();
    }
}
