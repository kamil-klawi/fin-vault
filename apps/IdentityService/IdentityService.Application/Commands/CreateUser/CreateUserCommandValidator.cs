using System.Data;
using FluentValidation;
using IdentityService.Application.Validator;

namespace IdentityService.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Email format is invalid!");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required!")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long!");

            RuleFor(user => user.Pesel)
                .NotEmpty().WithMessage("PESEL is required!")
                .Matches(@"^\d{11}$").WithMessage("PESEL format is invalid!");

            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name is required!")
                .MinimumLength(3).WithMessage("First name must be at least 3 characters long!");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Surname is required!")
                .MinimumLength(3).WithMessage("Surname must be at least 3 characters long!");

            RuleFor(user => user.Gender)
                .NotEmpty().WithMessage("Gender is required!")
                .IsInEnum().WithMessage("Gender must be a valid gender!");

            RuleFor(user => user.BirthDate)
                .NotEmpty().WithMessage("Birth date is required!")
                .LessThan(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Birth date cannot be in the future!")
                .Must(date => date <= DateOnly.FromDateTime(DateTime.Today.AddYears(-18))).WithMessage("User must be at least 18 years old!");

            RuleFor(user => user.PlaceOfBirth)
                .NotEmpty().WithMessage("Place of birth is required!")
                .MinimumLength(3).WithMessage("Place of birth must be at least 3 characters long!");

            RuleFor(user => user.Nationality)
                .NotEmpty().WithMessage("Nationality is required!");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required!")
                .Matches(@"^\d{9}$").WithMessage("Phone number format is invalid!");

            RuleFor(user => user.Address)
                .NotEmpty().WithMessage("Address is required!")
                .SetValidator(new AddressDtoValidator());
        }
    }
}
