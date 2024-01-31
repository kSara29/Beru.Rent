using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

public record BoolResponseDto(
    [property: JsonPropertyName("bool")] bool Bool
    );