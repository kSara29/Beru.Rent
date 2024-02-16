using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Notification.Application.Contracts;
using Notification.Application.Models;

namespace Notification.Appl.Services;

public class EmailNotificationService : INotificationService<EmailMessage>
{

    public async Task NotifyAsync(EmailMessage message)
    {
        try
        {
            var emailMessage = new MimeMessage();
          
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "login@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", message.ReceiverEmail));
            emailMessage.Subject = message.Template.Tytle;
            emailMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = message.Template.Body
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.yandex.ru", 25, false);
            await client.AuthenticateAsync("login@yandex.ru", "password");
            
            var result = await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}