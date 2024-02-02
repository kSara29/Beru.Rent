using System.Text.Json.Serialization;

namespace Chat.Dto.RequestDto;

public class SendMessageRequest
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("chatId")] public Guid ChatId { get; set; }
}