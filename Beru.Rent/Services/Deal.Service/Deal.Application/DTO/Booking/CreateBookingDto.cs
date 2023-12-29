using System.Runtime.InteropServices.JavaScript;

namespace Deal.Api.DTO.Booking;

[Serializable]
public record CreateBookingDto(
    string AdId,
    string TenantId,
    decimal Cost,
    DateTime Dbeg,
    DateTime Dend
);