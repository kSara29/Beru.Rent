using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record GetAllDealsRequestDto(
    [property: JsonPropertyName("ownerId")] string ownerId
 
);

