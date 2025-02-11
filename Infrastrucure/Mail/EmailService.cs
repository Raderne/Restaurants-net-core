using Application.Contracts.Infrastructure;
using Domain.Configurations;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Infrastrucure.Mail;

public class EmailService(IOptions<EmailOptions> options) : IEmailService
{
    private readonly EmailOptions _emailOptions = options.Value;
    public async Task SendEmailAsync(string email, string subject, string content)
    {
        try
        {
            var message = new MailMessage
            {
                From = new MailAddress("no-reply@test.com"),
                To = { new MailAddress(email) },
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };

            var emailMessage = new SmtpClient(_emailOptions.SmtpServer, _emailOptions.MailPort)
            {
                Credentials = new NetworkCredential(_emailOptions.Sender, _emailOptions.Password),
                EnableSsl = _emailOptions.UseSSL
            };

            await emailMessage.SendMailAsync(message);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to send email {ex.Message}");
        }
    }
}
