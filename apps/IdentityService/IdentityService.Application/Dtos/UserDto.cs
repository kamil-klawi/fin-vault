using IdentityService.Domain.Enums;
using SharedLibrary.Contracts.Common;

namespace IdentityService.Application.Dtos
{
    public record UserDto (
        Guid Id,
        string Email,
        string FirstName,
        string LastName,
        Gender Gender,
        DateOnly BirthDate,
        string PlaceOfBirth,
        string Nationality,
        string PhoneNumber,
        AddressDto Address,
        DateTime UpdatedAt,
        DateTime CreatedAt
    );
}
