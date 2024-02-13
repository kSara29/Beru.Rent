namespace Notification.Appl.Contracts;

public interface INotificationService<T>
{
    Task NotifyAsync(T message);
}