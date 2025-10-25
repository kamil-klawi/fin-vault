namespace IdentityService.Application.Dtos
{
    public record ResetPasswordRequest(string Email, string Token, string Password);
}
