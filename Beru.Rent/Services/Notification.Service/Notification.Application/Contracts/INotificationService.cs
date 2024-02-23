using Common;
using Notification.Dto.ResponseDto;

namespace Notification.Application.Contracts;

public interface INotificationService<T>
{
    Task<ResponseModel<SendMessageResponseDto>> NotifyAsync(T messageRequest);
}