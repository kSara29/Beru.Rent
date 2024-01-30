using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record CreateDealRequestDto(
    [property: JsonPropertyName("bookingId")] Guid bookingId,
    [property: JsonPropertyName("isApproved")] bool isApproved,
    [property: JsonPropertyName("isApproved")] string ownerId
);