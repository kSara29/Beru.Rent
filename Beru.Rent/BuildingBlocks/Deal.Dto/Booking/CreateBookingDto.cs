namespace Deal.Dto.Booking;

[Serializable]
public record CreateBookingDto(
    Guid AdId,
    Guid TenantId,
    DateTime Dbeg,
    DateTime Dend
);