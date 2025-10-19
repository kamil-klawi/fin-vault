using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Common.Exceptions;

namespace SharedLibrary.Contracts.User
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUser GetCurrentUser()
        {
            ClaimsPrincipal? user = httpContextAccessor.HttpContext?.User;

            if (user is null || !user.Identity?.IsAuthenticated == true)
                throw new UnauthorizedException("User is not authenticated");

            string? idClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(idClaim, out Guid userId))
                throw new UnauthorizedException("User is not authenticated");

            string email = user.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
            string phoneNumber = user.FindFirst(ClaimTypes.MobilePhone)?.Value ?? string.Empty;
            List<string> roles = user.FindAll(ClaimTypes.Role)
                .Select(claim => claim.Value)
                .ToList();
            List<string> permissions = user.FindAll("permission")
                .Select(claim => claim.Value)
                .ToList();

            return new CurrentUser
            {
                Id = userId,
                PhoneNumber = phoneNumber,
                Email = email,
                Roles = roles,
                Permissions = permissions,
            };
        }
    }
}
