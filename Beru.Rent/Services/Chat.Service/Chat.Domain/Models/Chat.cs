namespace Chat.Domain.Models;

public class Chat
{
    public Guid ChatId { get; init; }
    public DateTime CreatedAt { get; init; }
    public string[] ParticipantUserId { get; set; }

}