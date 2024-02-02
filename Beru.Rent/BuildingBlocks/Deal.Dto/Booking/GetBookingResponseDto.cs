using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetBookingResponseDto(
    [property: JsonPropertyName("Id")]Guid Id,
    [property: JsonPropertyName("adId")]Guid AdId,
    [property: JsonPropertyName("tenantId")]string TenantId,
    [property: JsonPropertyName("dbeg")]DateTime Dbeg,
    [property: JsonPropertyName("dend")]DateTime Dend,
    [property: JsonPropertyName("cost")]decimal? Cost,
    [property: JsonPropertyName("bookingState")]string BookingState, 
    [property: JsonPropertyName("OwnerId")]string OwnerId
    );