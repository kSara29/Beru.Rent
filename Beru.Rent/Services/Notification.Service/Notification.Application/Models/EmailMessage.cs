namespace Notification.Appl.Models;

public class EmailMessage
{
    public Guid MessageId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string ReceiverEmail { get; set; }
    public Template Template { get; set; }
}