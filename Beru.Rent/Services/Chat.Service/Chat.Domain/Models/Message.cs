namespace Chat.Domain.Models;

public class Message
{
    public Guid MessageId { get; init; }
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; }
    public Guid SenderId { get; set; }
    public string Text { get; set; }
    public DateTime Timestamp { get; set; }
    public bool IsRead { get; set; }
    public Attachment[] Attachments { get; set; }
}