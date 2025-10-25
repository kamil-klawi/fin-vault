namespace IdentityService.Application.Services.ResetPassword
{
    public interface IResetPassword
    {
        Task<string?> GeneratePasswordResetTokenAsync(string email);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
    }
}
