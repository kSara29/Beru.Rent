using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public class GetBookingResponseDto
{
    [property: JsonPropertyName("id")] public Guid Id { get; set; }
    [property: JsonPropertyName("adId")] public Guid AdId { get; set; }
    [property: JsonPropertyName("tenantId")] public string TenantId { get; set; }
    [property: JsonPropertyName("dbeg")] public DateTime Dbeg { get; set; }
    [property: JsonPropertyName("dend")] public DateTime Dend { get; set; }
    [property: JsonPropertyName("cost")] public decimal? Cost { get; set; }
    [property: JsonPropertyName("bookingState")] public string BookingState { get; set; }
    [property: JsonPropertyName("ownerId")] public string OwnerId { get; set; }
    [property: JsonPropertyName("ownerName")] public  string? OwnerName { get; set; }
    [property: JsonPropertyName("tenantName")] public  string? TenantName { get; set; }
}