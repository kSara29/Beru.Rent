using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record CreateDealResponseDto(
    [property: JsonPropertyName("dealId")] Guid DealId,
    [property: JsonPropertyName("boolean")] bool Boolean
    
);