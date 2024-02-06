namespace Chat.Dto.ResponseModel;

public class MessageDto
{
    public Guid MessageId { get; set; }
    public Guid SenderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Text { get; set; }
}