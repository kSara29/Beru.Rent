namespace Notification.Application.Contracts;

public interface INotificationService<T>
{
    Task NotifyAsync(T message);
}