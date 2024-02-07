using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetDealResponseDto(
    [property: JsonPropertyName("id")] Guid Id,
    [property: JsonPropertyName("adId")] Guid AdId,
    [property: JsonPropertyName("tenantId")] string TenantId,
    [property: JsonPropertyName("dbeg")] DateTime Dbeg,
    [property: JsonPropertyName("dend")] DateTime Dend,
    [property: JsonPropertyName("cost")] decimal? Cost,
    [property: JsonPropertyName("deposit")] decimal? Deposit,
    [property: JsonPropertyName("chatId")] Guid? ChatId, 
    [property: JsonPropertyName("ownerId")] string OwnerId,
    [property: JsonPropertyName("ownerName")] string? OwnerName,
    [property: JsonPropertyName("tenantName")] string? TenantName


    
);