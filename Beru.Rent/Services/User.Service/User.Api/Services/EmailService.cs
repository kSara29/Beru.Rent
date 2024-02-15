using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace User.Api.Services;

public class EmailService(MimeMessage emailMessage) : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        emailMessage.From.Add(new MailboxAddress("Администрация сайта", "admin@berurent.com"));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = message
        };
             
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.yandex.ru", 465, true);
            await client.AuthenticateAsync("example@yandex.ru", "your_password");
            await client.SendAsync(emailMessage);
 
            await client.DisconnectAsync(true);
        }
    }
}