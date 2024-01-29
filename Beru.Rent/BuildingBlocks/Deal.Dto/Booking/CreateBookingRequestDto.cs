using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record CreateBookingRequestDto(
    [property: JsonPropertyName("adId")] Guid AdId,
    [property: JsonPropertyName("TenantId")] Guid TenantId,
    [property: JsonPropertyName("Dbeg")] DateTime Dbeg,
    [property: JsonPropertyName("Dend")] DateTime Dend
);