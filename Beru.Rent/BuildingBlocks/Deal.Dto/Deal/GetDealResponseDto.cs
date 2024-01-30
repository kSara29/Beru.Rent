using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetDealResponseDto(
    [property: JsonPropertyName("DealId")] Guid dealId,
    [property: JsonPropertyName("AdId")] Guid adId,
    [property: JsonPropertyName("TenantId")] string tenantId,
    [property: JsonPropertyName("Dbeg")] DateTime dbeg,
    [property: JsonPropertyName("Dend")] DateTime dend,
    [property: JsonPropertyName("Cost")] decimal cost,
    [property: JsonPropertyName("Deposit")] decimal? Deposit,
    [property: JsonPropertyName("ChatId")] Guid? chatId
    
    
);