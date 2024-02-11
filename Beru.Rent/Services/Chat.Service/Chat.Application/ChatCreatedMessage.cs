namespace Chat.Application;

public class ChatCreatedMessage
{
    public Guid DealId { get; set; } 
    public List<string> Users { get; set; } 
}