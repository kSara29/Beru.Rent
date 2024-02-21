namespace Notification.Application.Options;

public class EmailSenderOptions
{
    public required string Url { get; init; }
    public required int Port { get; init; }
    public required string From { get; init; }
    public required string Password { get; init; }
}