using AutoMapper;
using IdentityService.Application.Dtos;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedLibrary.Common.Exceptions;
using SharedLibrary.Common.ValueObjects;

namespace IdentityService.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler(
        ILogger<UpdateUserCommandHandler> logger,
        IMapper mapper,
        IUserRepository userRepository
        ) : IRequestHandler<UpdateUserCommand, UserDto>
    {
        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating user details");
            User user = await userRepository.GetUserAsync(request.Id);
            if (user is null)
                throw new NotFoundException($"User with ID {request.Id} not found");

            user.UpdatePersonalData(request.FirstName, request.LastName, new PhoneNumber(request.PhoneNumber));
            User updatedUser = await userRepository.UpdateUserAsync(user);
            return mapper.Map<UserDto>(updatedUser);
        }
    }
}
