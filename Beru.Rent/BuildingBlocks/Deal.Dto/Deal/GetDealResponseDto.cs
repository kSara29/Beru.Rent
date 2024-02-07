using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetDealResponseDto(
    [property: JsonPropertyName("dealId")] Guid dealId,
    [property: JsonPropertyName("adId")] Guid adId,
    [property: JsonPropertyName("tenantId")] string tenantId,
    [property: JsonPropertyName("dbeg")] DateTime dbeg,
    [property: JsonPropertyName("dend")] DateTime dend,
    [property: JsonPropertyName("cost")] decimal? cost,
    [property: JsonPropertyName("deposit")] decimal? Deposit,
    [property: JsonPropertyName("chatId")] Guid? chatId
    
    
);