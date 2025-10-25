using FluentValidation;
using SharedLibrary.Contracts.Common;

namespace IdentityService.Application.Validator
{
    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(address => address.City)
                .NotEmpty().WithMessage("City is required!");

            RuleFor(address => address.Country)
                .NotEmpty().WithMessage("Country is required!");

            RuleFor(address => address.PostalCode)
                .NotEmpty().WithMessage("PostalCode is required!")
                .Matches(@"^\d{2}-\d{3}$").WithMessage("Postal code format is invalid!");

            RuleFor(address => address.Street)
                .NotEmpty().WithMessage("Street is required!");
        }
    }
}
