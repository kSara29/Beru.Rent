using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public class CloseDealRequestDto
{
    [property: JsonPropertyName("id")] public Guid Id { get; set; }

    [property: JsonPropertyName("userId")] public string? UserId { get; set; }
}