using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record CloseDealResponseDto(
    [property: JsonPropertyName("boolean")] bool Boolean
);