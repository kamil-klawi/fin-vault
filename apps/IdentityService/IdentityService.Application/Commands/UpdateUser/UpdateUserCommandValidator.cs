using FluentValidation;

namespace IdentityService.Application.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name is required!")
                .MinimumLength(3).WithMessage("First name must be at least 3 characters long!");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Surname is required!")
                .MinimumLength(3).WithMessage("Surname must be at least 3 characters long!");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required!")
                .Matches(@"^\d{9}$").WithMessage("Phone number format is invalid!");
        }
    }
}
