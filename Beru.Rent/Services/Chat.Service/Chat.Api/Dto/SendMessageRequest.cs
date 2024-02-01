namespace Chat.Api.Dto;

public class SendMessageRequest
{
    public string Message { get; set; }
    public Guid ChatId { get; set; }
}