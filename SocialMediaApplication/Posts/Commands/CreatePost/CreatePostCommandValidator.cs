using FluentValidation;

namespace SocialMediaApplication.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .When(p => p.Title != null);

            RuleFor(p => p.Description)
                .NotEmpty()
                .When(p => p.Description != null);

            RuleFor(p => p)
                .Must(AtLeastOnePropertyNotNull)
                .WithMessage("At least one of Title or Description must be provided.");
        }

        private bool AtLeastOnePropertyNotNull(CreatePostCommand command)
        {
            return !string.IsNullOrWhiteSpace(command.Title) ||
                   !string.IsNullOrWhiteSpace(command.Description);
        }
    }
}
