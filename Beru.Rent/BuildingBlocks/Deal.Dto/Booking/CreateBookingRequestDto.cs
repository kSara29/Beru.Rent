using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public class CreateBookingRequestDto
{
    [property: JsonPropertyName("adId")] public Guid AdId { get; set; }
    [property: JsonPropertyName("TenantId")] public string TenantId { get; set; }
    [property: JsonPropertyName("Cost")] public decimal? Cost { get; set; }
    [property: JsonPropertyName("Dbeg")] public DateTime Dbeg { get; set; }
    [property: JsonPropertyName("Dend")] public DateTime Dend { get; set; }
    
}