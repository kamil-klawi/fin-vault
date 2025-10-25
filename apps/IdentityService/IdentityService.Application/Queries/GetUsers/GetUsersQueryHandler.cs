using AutoMapper;
using IdentityService.Application.Dtos;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedLibrary.Contracts.Common;

namespace IdentityService.Application.Queries.GetUsers
{
    public class GetUsersQueryHandler(
        ILogger<GetUsersQueryHandler> logger,
        IMapper mapper,
        IUserRepository userRepository
        ) : IRequestHandler<GetUsersQuery, PagedResult<UserDto>>
    {
        public async Task<PagedResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving all users");
            PagedResult<User> users = await userRepository.GetUsersAsync(request.PageNumber, request.PageSize);
            return mapper.Map<PagedResult<UserDto>>(users);
        }
    }
}
