using System.Runtime.InteropServices.JavaScript;

namespace Deal.Api.DTO.Booking;

[Serializable]
public record CreateBookingDto(
    Guid AdId,
    Guid TenantId,
    decimal Cost,
    DateTime Dbeg,
    DateTime Dend
);