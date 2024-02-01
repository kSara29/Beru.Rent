using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record CreateDealResponseDto(
    [property: JsonPropertyName("DealId")] Guid dealId
);