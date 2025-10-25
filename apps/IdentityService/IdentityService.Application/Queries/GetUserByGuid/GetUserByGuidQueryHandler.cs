using AutoMapper;
using IdentityService.Application.Dtos;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.Queries.GetUserByGuid
{
    public class GetUserByGuidQueryHandler(
        ILogger<GetUserByGuidQueryHandler> logger,
        IMapper mapper,
        IUserRepository userRepository
        ) : IRequestHandler<GetUserByGuidQuery, UserDto>
    {
        public async Task<UserDto> Handle(GetUserByGuidQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving user by Id {Id}", request.Id);
            User user = await userRepository.GetUserAsync(request.Id);
            return mapper.Map<UserDto>(user);
        }
    }
}
