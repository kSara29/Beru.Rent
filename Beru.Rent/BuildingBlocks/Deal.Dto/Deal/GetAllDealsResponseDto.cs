using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetAllDealsResponseDto(
    [property: JsonPropertyName("dealId")] Guid DealId,
    [property: JsonPropertyName("dbeg")] DateTime Dbeg,
    [property: JsonPropertyName("dend")] DateTime Dend,
    [property: JsonPropertyName("cost")] decimal? Cost
);