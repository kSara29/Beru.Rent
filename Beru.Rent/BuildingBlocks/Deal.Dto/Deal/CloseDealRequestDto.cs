using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record CloseDealRequestDto(
    [property: JsonPropertyName("id")] Guid Id,
    [property: JsonPropertyName("userId")] string UserId
);