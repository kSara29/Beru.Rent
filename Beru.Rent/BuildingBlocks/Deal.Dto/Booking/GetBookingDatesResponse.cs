using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

public record GetBookingDatesResponse(
    [property: JsonPropertyName("Dbeg")] DateTime Dbeg,
    [property: JsonPropertyName("Dend")] DateTime Dend
);