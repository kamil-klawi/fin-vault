using System.Security.Cryptography;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Application.Services.ResetPassword
{
    public class ResetPassword(
        IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher
        ) : IResetPassword
    {
        public async Task<string?> GeneratePasswordResetTokenAsync(string email)
        {
            User user = await userRepository.GetUserByEmailAsync(email);
            byte[] tokenBytes = new byte[16];
            RandomNumberGenerator.Fill(tokenBytes);
            string token = Convert.ToBase64String(tokenBytes);
            user.SetPasswordResetToken(token, DateTime.UtcNow.AddHours(1));
            await userRepository.UpdateUserAsync(user);
            return token;
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            User user = await userRepository.GetUserByEmailAsync(email);
            if (user.PasswordResetToken != token || user.PasswordResetTokenExpires < DateTime.UtcNow)
                throw new InvalidOperationException("Invalid or expired token.");

            string hashedPassword = passwordHasher.HashPassword(user, newPassword);
            user.ChangePassword(hashedPassword);
            user.SetPasswordResetToken(null, null);
            await userRepository.UpdateUserAsync(user);
            return true;
        }
    }
}
