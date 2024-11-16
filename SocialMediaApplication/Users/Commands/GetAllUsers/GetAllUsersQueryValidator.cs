using FluentValidation;

namespace SocialMediaApplication.Users.Commands.GetAllUsers;

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    private readonly List<int> allowedSizes = [10, 20, 30, 50, 100];

    public GetAllUsersQueryValidator()
    {
        RuleFor(q => q.PageSize)
            .Must(allowedSizes.Contains)
            .WithMessage("PageSize must be in: [10, 20, 30, 50, 100]");

        RuleFor(q => q.PageNumber)
            .GreaterThanOrEqualTo(1);
    }
}
