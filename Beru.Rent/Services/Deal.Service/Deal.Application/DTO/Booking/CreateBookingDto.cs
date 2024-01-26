using System.Runtime.InteropServices.JavaScript;

namespace Deal.Api.DTO.Booking;

[Serializable]
public record CreateBookingDto(
    Guid AdId,
    Guid TenantId,
    DateTime Dbeg,
    DateTime Dend
);