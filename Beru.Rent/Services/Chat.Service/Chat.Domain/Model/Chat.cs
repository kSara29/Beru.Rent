using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat.Domain.Model;

public class Chat
{
    [BsonId]
    public Guid Id { get; set; }
    public List<string> Participants { get; set; } = new List<string>();
    public DateTime CreatedAt { get; set; }
    public List<Message> Messages { get; set; }
}