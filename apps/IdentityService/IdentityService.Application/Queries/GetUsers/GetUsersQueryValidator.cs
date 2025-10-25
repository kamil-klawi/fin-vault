using FluentValidation;

namespace IdentityService.Application.Queries.GetUsers
{
    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        private readonly int[] _allowPagesSizes = [5, 10, 15, 20, 25];

        public GetUsersQueryValidator()
        {
            RuleFor(pageResult => pageResult.PageNumber).GreaterThanOrEqualTo(1);

            RuleFor(pageResult => pageResult.PageSize)
                .Must(value => _allowPagesSizes.Contains(value))
                .WithMessage($"Page size must be in the range [{string.Join(",", _allowPagesSizes)}].");
        }
    }
}
