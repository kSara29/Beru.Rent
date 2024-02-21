using Common;
using FastEndpoints;
using Notification.Application.Contracts;
using Notification.Dto.RequestDto;
using Notification.Dto.ResponseDto;

namespace Notification.Api.Endpoints;

public class EmailNotification(INotificationService<SendMessageRequestDto> notificationService) : Endpoint<SendMessageRequestDto, ResponseModel<SendMessageResponseDto>>
{
    public override void Configure()
    {
        Post("/api/notification/send");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SendMessageRequestDto message, CancellationToken ct)
    {
        await notificationService.NotifyAsync(message);
        
    }
}