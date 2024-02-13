using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Notification.Appl.Contracts;
using Notification.Appl.Models;

namespace Notification.Appl.Services;

public class EmailNotificationService : INotificationService<EmailMessage>
{

    public async Task NotifyAsync(EmailMessage message)
    {
        try
        {
            //bookItem (email)
            //confirmBooking ??
            var emailMessage = new MimeMessage();
            //var user = bd.GetById(string id)
            //сделать Worker. Перед отправкой мылв продавцу, сожать сообщение в БД со статусом "в процессе отправки"
            //если сообщение отправилось, меняем статус на "отправлено"
            //при неудаче меняем статус сообщения "warning"
            //worker выгребает все сообщения со статусом "warning" и пытается отправить их. 
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
            
            //todo: проверить что возвращается при успешной отправке и неуспешной
            var result = await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            //todo: что делать с сообщением при неуспехе?
        }
    }
}
