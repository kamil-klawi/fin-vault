using IdentityService.Application.Commands.DeleteUser.DeleteUserByEmail;
using IdentityService.Application.Commands.DeleteUser.DeleteUserByGuid;
using IdentityService.Application.Commands.UpdateUser;
using IdentityService.Application.Dtos;
using IdentityService.Application.Queries.GetUserByEmail;
using IdentityService.Application.Queries.GetUserByGuid;
using IdentityService.Application.Queries.GetUsers;
using IdentityService.Presentation.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Contracts.Common;

namespace IdentityService.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PagedResult<UserDto>>> GetUsers([FromQuery] GetUsersQuery query)
        {
            PagedResult<UserDto> users = await mediator.Send(new GetUsersQuery(query.PageNumber,query.PageSize));
            return Ok(users);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDto>> GetUserById([FromQuery] GetUserByGuidQuery query)
        {
            UserDto user = await mediator.Send(new GetUserByGuidQuery(query.Id));
            return Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDto>> GetUserByEmail([FromQuery] GetUserByEmailQuery query)
        {
            UserDto user = await mediator.Send(new GetUserByEmailQuery(query.Email));
            return Ok(user);
        }

        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDto>> GetUserById()
        {
            UserDto userDto = await mediator.Send(new GetUserByGuidQuery(GetUserIdFromClaims.GetUserIdFromClaimsHelper(User)));
            return Ok(userDto);
        }

        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDto>> GetUserByEmail()
        {
            UserDto userDto = await mediator.Send(new GetUserByEmailQuery(GetUserEmailFromClaims.GetUserEmailFromClaimsHelper(User)));
            return Ok(userDto);
        }

        [HttpPatch("me")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UpdateUserCommand command)
        {
            command = command with { Id = GetUserIdFromClaims.GetUserIdFromClaimsHelper(User) };
            UserDto updatedUser = await mediator.Send(command);
            return Ok(updatedUser);
        }

        [HttpDelete("me")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUserById()
        {
            await mediator.Send(new DeleteUserByGuidCommand(GetUserIdFromClaims.GetUserIdFromClaimsHelper(User)));
            return NoContent();
        }

        [HttpDelete("me")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUserByEmail()
        {
            await mediator.Send(new DeleteUserByEmailCommand(GetUserEmailFromClaims.GetUserEmailFromClaimsHelper(User)));
            return NoContent();
        }
    }
}
