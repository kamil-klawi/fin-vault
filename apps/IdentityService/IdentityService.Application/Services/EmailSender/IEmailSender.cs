namespace IdentityService.Application.Services.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string toEmail, string subject, string plainTextMessage);
    }
}
