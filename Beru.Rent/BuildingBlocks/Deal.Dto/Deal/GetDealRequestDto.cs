using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetDealRequestDto(
    [property: JsonPropertyName("DealId")] Guid dealId
);