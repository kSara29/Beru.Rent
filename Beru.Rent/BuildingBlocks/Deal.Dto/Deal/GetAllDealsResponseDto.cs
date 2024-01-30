using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetAllDealsResponseDto(
    [property: JsonPropertyName("DealId")] Guid DealId,
    [property: JsonPropertyName("Dbeg")] DateTime Dbeg,
    [property: JsonPropertyName("Dend")] DateTime Dend,
    [property: JsonPropertyName("Cost")] decimal? Cost
);