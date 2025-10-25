using MediatR;

namespace IdentityService.Application.Commands.DeleteUser.DeleteUserByGuid
{
    public record DeleteUserByGuidCommand(Guid Id) : IRequest;
}
