using IdentityService.Domain.Entities;

namespace IdentityService.Application.Services.AuthService
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string email, string password);
        Task<User?> ValidateTokenAsync(string token);
    }
}
