using IdentityService.Domain.Entities;
using IdentityService.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedLibrary.Common.Exceptions;

namespace IdentityService.Application.Commands.DeleteUser.DeleteUserByEmail
{
    public class DeleteUserByEmailCommandHandler(
        ILogger<DeleteUserByEmailCommandHandler> logger,
        IUserRepository userRepository
        ) : IRequestHandler<DeleteUserByEmailCommand>
    {
        public async Task Handle(DeleteUserByEmailCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting user {@request}", request);
            User user = await userRepository.GetUserByEmailAsync(request.Email);
            if (user is null)
                throw new NotFoundException($"User with email {request.Email} not found");
            await userRepository.DeleteUserByEmailAsync(user.Email);
        }
    }
}
