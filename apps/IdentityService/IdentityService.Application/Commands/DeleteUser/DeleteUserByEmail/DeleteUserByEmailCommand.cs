using MediatR;

namespace IdentityService.Application.Commands.DeleteUser.DeleteUserByEmail
{
    public record DeleteUserByEmailCommand(string Email) : IRequest;
}
