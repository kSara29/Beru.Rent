using System.Text.Json.Serialization;

namespace Deal.Dto.Booking;

[Serializable]
public record CreateDealRequestDto(
    [property: JsonPropertyName("bookingId")] Guid BookingId,
    [property: JsonPropertyName("isApproved")] bool IsApproved,
    [property: JsonPropertyName("ownerId")] string OwnerId
);