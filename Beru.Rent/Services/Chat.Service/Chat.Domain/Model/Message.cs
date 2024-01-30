using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat.Domain.Model;

public class Message
{  
    [BsonId]
    /*[BsonRepresentation(BsonType.ObjectId)]*/
    public Guid MessageId { get; set; }
    public Guid SenderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Text { get; set; }
}