using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetAllBookingsResponseDto(
    [property: JsonPropertyName("BookingId")] Guid BookingId,
    [property: JsonPropertyName("Dbeg")] DateTime Dbeg,
    [property: JsonPropertyName("Dend")] DateTime Dend,
    [property: JsonPropertyName("Cost")] decimal? Cost
);