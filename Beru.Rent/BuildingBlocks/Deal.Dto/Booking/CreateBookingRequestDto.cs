using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public class CreateBookingRequestDto
{
    [property: JsonPropertyName("adId")] public Guid AdId { get; set; }
    [property: JsonPropertyName("tenantId")] public string TenantId { get; set; }
    [property: JsonPropertyName("cost")] public decimal? Cost { get; set; }
    [property: JsonPropertyName("dbeg")] public DateTime Dbeg { get; set; }
    [property: JsonPropertyName("dend")] public DateTime Dend { get; set; }
    
    [property: JsonPropertyName("OwnerId")] public string OwnerId { get; set; }
}