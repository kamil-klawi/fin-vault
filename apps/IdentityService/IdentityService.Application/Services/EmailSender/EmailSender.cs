using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace IdentityService.Application.Services.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly string? _smtpHost = Environment.GetEnvironmentVariable("SMTP_HOST");
        private readonly int _smtpPort = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT"));
        private readonly string? _smtpUser = Environment.GetEnvironmentVariable("SMTP_USER");
        private readonly string? _smtpPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
        private readonly string? _fromEmail = Environment.GetEnvironmentVariable("FROM_EMAIL");

        public async Task SendEmailAsync(string toEmail, string subject, string plainTextMessage)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_fromEmail));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = plainTextMessage };

            using SmtpClient smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpHost, _smtpPort, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpUser, _smtpPassword);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
