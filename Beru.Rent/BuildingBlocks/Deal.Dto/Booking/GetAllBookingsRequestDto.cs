using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetAllBookingsRequestDto(
    [property: JsonPropertyName("AdId")] Guid AdId
);