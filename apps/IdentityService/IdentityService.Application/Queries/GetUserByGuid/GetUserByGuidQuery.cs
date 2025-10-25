using IdentityService.Application.Dtos;
using MediatR;

namespace IdentityService.Application.Queries.GetUserByGuid
{
    public record GetUserByGuidQuery(Guid Id) : IRequest<UserDto>;
}
