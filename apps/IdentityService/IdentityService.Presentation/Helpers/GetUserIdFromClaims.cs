using System.Security.Claims;

namespace IdentityService.Presentation.Helpers
{
    public static class GetUserIdFromClaims
    {
        public static Guid GetUserIdFromClaimsHelper(ClaimsPrincipal user)
        {
            string? userIdClaim = user.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userIdClaim is null)
                throw new UnauthorizedAccessException("User is not authenticated!");

            return Guid.Parse(userIdClaim);
        }
    }
}
