using System.Text.Json.Serialization;
using Deal.Domain.Enums;

namespace Deal.Api.DTO;

[Serializable]
public record BookingDto(
    
    [property: JsonPropertyName("adId")]string AdId,
    [property: JsonPropertyName("tenantId")]string TenantId,
    [property: JsonPropertyName("dbeg")]DateTime Dbeg,
    [property: JsonPropertyName("dend")]DateTime Dend,
    [property: JsonPropertyName("cost")]decimal Cost,
    [property: JsonPropertyName("bookingState")]string BookingState
    );