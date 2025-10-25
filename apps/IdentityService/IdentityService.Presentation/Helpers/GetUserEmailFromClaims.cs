using System.Security.Claims;

namespace IdentityService.Presentation.Helpers
{
    public class GetUserEmailFromClaims
    {
        public static string GetUserEmailFromClaimsHelper(ClaimsPrincipal user)
        {
            string? emailClaim = user.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
            if (emailClaim == null)
                throw new UnauthorizedAccessException("User is not authenticated!");

            return emailClaim;
        }
    }
}
