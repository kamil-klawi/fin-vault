using AutoMapper;
using IdentityService.Application.Dtos;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler(
        ILogger<GetUserByEmailQueryHandler> logger,
        IMapper mapper,
        IUserRepository userRepository
        ) : IRequestHandler<GetUserByEmailQuery, UserDto>
    {
        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving user by email {Email}", request.Email);
            User user = await userRepository.GetUserByEmailAsync(request.Email);
            return mapper.Map<UserDto>(user);
        }
    }
}
