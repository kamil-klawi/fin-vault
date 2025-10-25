using IdentityService.Domain.Entities;
using IdentityService.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedLibrary.Common.Exceptions;

namespace IdentityService.Application.Commands.DeleteUser.DeleteUserByGuid
{
    public class DeleteUserByGuidCommandHandler(
        ILogger<DeleteUserByGuidCommandHandler> logger,
        IUserRepository userRepository
        ) : IRequestHandler<DeleteUserByGuidCommand>
    {
        public async Task Handle(DeleteUserByGuidCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting user {@request}", request);
            User user = await userRepository.GetUserAsync(request.Id);
            if (user is null)
                throw new NotFoundException($"User with ID {request.Id} not found");
            await userRepository.DeleteUserAsync(user.Id);
        }
    }
}
