namespace Chat.Dto.RequestDto;

public class SendMessageRequest
{
    public string Message { get; set; }
    public Guid ChatId { get; set; }
}