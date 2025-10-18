using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace SharedLibrary.Common.Security
{
    public static class AuthorizationPolicies
    {
        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            IEnumerable<string> permissions = GetAllPermissions();

            services.AddAuthorizationCore(options =>
            {
                foreach (string permission in permissions)
                {
                    options.AddPolicy($"Permission:{permission}", policy =>
                        policy.RequireClaim("permission", permission));
                }
            });
        }

        private static IEnumerable<string> GetAllPermissions()
        {
            Type permissionType = typeof(Permissions);
            return permissionType
                .GetNestedTypes(BindingFlags.Public | BindingFlags.Static)
                .SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static))
                .Where(fieldInfo => fieldInfo.FieldType == typeof(string))
                .Select(fieldInfo => fieldInfo.GetValue(null)?.ToString())
                .Where(value => !string.IsNullOrEmpty(value))!;
        }
    }
}
