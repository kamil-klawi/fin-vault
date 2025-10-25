using IdentityService.Application.Dtos;
using MediatR;

namespace IdentityService.Application.Queries.GetUserByEmail
{
    public record GetUserByEmailQuery(string Email) : IRequest<UserDto>;
}
