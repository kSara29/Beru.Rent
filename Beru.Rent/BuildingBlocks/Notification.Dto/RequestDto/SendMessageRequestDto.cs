namespace Notification.Dto.RequestDto;

public class SendMessageRequestDto
{
    public required string Email { get; set; }
    public required string Subject { get; set; }
    public required string Message { get; set; }
}
