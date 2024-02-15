using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using User.Api.JsonOptions;

namespace User.Api.Services;

public class EmailService(IOptions<EmailSender> options)
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Администрация сайта", "aleksejrozhdestvin@yandex.ru"));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = message
        };
             
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.yandex.com", 465, true);
            await client.AuthenticateAsync("aleksejrozhdestvin@yandex.ru", "jpngojziuoslonms");
            await client.SendAsync(emailMessage);
 
            await client.DisconnectAsync(true);
        }
    }
}