using IdentityService.Application.Dtos;
using IdentityService.Domain.Enums;
using MediatR;
using SharedLibrary.Contracts.Common;

namespace IdentityService.Application.Commands.CreateUser
{
    public record CreateUserCommand(
        string Email,
        string Password,
        string FirstName,
        string LastName,
        string Pesel,
        Gender Gender,
        DateOnly BirthDate,
        string PlaceOfBirth,
        string Nationality,
        string PhoneNumber,
        AddressDto Address
    ) : IRequest<UserDto>;
}
