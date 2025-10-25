using IdentityService.Application.Dtos;
using MediatR;
using SharedLibrary.Contracts.Common;

namespace IdentityService.Application.Queries.GetUsers
{
    public record GetUsersQuery(int PageNumber, int PageSize) : IRequest<PagedResult<UserDto>>;
}
