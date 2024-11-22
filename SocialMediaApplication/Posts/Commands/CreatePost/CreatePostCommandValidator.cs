using FluentValidation;

namespace SocialMediaApplication.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(p => p.Content)
                .NotEmpty();
        }
    }
}
