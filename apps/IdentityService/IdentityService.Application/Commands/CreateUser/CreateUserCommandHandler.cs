using AutoMapper;
using IdentityService.Application.Dtos;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler(
        ILogger<CreateUserCommandHandler> logger,
        IMapper mapper,
        IUserRepository userRepository
        ) : IRequestHandler<CreateUserCommand, UserDto>
    {
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new user");
            User user = mapper.Map<User>(request);
            User entity = await userRepository.CreateUserAsync(user);
            return mapper.Map<UserDto>(entity);
        }
    }
}
