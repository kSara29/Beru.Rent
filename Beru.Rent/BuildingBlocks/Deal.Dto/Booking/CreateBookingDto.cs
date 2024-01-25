namespace Deal.Dto.Booking;

[Serializable]
public record CreateBookingDto(
    Guid AdId,
    Guid TenantId,
    decimal Cost,
    DateTime Dbeg,
    DateTime Dend
);