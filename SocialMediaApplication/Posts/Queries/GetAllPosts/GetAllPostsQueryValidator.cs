using FluentValidation;

namespace SocialMediaApplication.Posts.Queries.GetAllPosts;

public class GetAllPostsQueryValidator : AbstractValidator<GetAllPostsQuery>
{
    private readonly List<int> allowedPageSizes = [5, 10, 15, 20, 30];
    public GetAllPostsQueryValidator()
    {
        RuleFor(q => q.PageSize)
            .Must(allowedPageSizes.Contains)
            .WithMessage("Page size must be in [5, 10, 15, 20, 30]");

        RuleFor(q => q.searchPhase)
            .NotEmpty()
            .When(q => q.searchPhase != null);
    }
}
