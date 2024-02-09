using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetAllBookingsResponseDto(
    [property: JsonPropertyName("bookingId")] Guid BookingId,
    [property: JsonPropertyName("dbeg")] DateTime Dbeg,
    [property: JsonPropertyName("dend")] DateTime Dend,
    [property: JsonPropertyName("cost")] decimal? Cost
);