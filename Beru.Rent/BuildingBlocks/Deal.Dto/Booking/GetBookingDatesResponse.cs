using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

public record GetBookingDatesResponse(
    [property: JsonPropertyName("dbeg")] DateTime Dbeg,
    [property: JsonPropertyName("dend")] DateTime Dend
);