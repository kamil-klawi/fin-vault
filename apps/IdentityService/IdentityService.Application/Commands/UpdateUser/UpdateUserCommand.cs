using IdentityService.Application.Dtos;
using MediatR;

namespace IdentityService.Application.Commands.UpdateUser
{
    public record UpdateUserCommand(Guid Id, string FirstName, string LastName, string PhoneNumber) : IRequest<UserDto>;
}
