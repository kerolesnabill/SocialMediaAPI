using FluentValidation;

namespace SocialMediaApplication.Posts.Queries.GetFeed;

public class GetFeedQueryValidator : AbstractValidator<GetFeedQuery>
{
    private readonly List<int> allowedPageSizes = [5, 10, 15, 20, 30];

    public GetFeedQueryValidator()
    {
        RuleFor(q => q.PageSize)
            .Must(allowedPageSizes.Contains)
            .WithMessage("Page size must be in [5, 10, 15, 20, 30]");

        RuleFor(q => q.searchPhase)
            .NotEmpty()
            .When(q => q.searchPhase != null);
    }
}
