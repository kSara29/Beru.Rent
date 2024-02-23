using Common;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Notification.Application.Contracts;
using Notification.Application.Options;
using Notification.Dto.RequestDto;
using Notification.Dto.ResponseDto;

namespace Notification.Application.Services;

public class EmailNotificationService(
    IOptions<EmailSenderOptions> options) : INotificationService<SendMessageRequestDto>
{
    private readonly EmailSenderOptions _options = options.Value;

    public async Task<ResponseModel<SendMessageResponseDto>> NotifyAsync(SendMessageRequestDto messageRequest)
    {
        try
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", _options.From));
            emailMessage.To.Add(new MailboxAddress("", messageRequest.Email));
            emailMessage.Subject = messageRequest.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = messageRequest.Message
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(_options.Url, _options.Port, true);
            await client.AuthenticateAsync(_options.From, _options.Password);
            await client.SendAsync(emailMessage);
 
            await client.DisconnectAsync(true);
            return ResponseModel<SendMessageResponseDto>.CreateSuccess(new SendMessageResponseDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return ResponseModel<SendMessageResponseDto>.CreateFailed([
                new ResponseError
                {
                    Message = "Ошибка при отправке письма пользователю",
                    Code = "500"
                }
            ]);
        }
    }
}