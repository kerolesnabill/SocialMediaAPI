using FluentValidation;

namespace SocialMediaApplication.Users.Queries.SearchForUser;

public class SearchForUserQueryValidator : AbstractValidator<SearchForUserQuery>
{
    public SearchForUserQueryValidator()
    {
        RuleFor(q => q.SearchPhase)
            .NotEmpty();
    }
}
