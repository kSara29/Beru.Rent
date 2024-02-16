using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public class GetDealRequestDto
{
    [property: JsonPropertyName("dealId")] public Guid? DealId { get; set; }
}
