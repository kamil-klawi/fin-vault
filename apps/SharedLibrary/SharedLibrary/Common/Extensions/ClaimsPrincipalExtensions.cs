using System.Security.Claims;

namespace SharedLibrary.Common.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool HasPermission(this ClaimsPrincipal principal, string permission)
        {
            return principal.Claims.Any(c =>
                c.Type == "permission" &&
                c.Value.Equals(permission, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasAnyPermission(this ClaimsPrincipal principal, params string[] permission)
        {
            HashSet<string> permissions = principal
                .FindAll("permission")
                .Select(claim => claim.Value)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            return permissions.Any(value => permissions.Contains(value));
        }

        public static IEnumerable<string> GetPermissions(this ClaimsPrincipal principal)
        {
            return principal.FindAll("permission").Select(claim => claim.Value);
        }

        public static bool HasRole(this ClaimsPrincipal principal, string role)
        {
            return principal.IsInRole(role);
        }

        public static string? GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static string? GetUserEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}
