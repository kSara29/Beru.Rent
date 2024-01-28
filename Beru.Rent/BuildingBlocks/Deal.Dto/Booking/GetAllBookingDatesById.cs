using FastEndpoints;

namespace Deal.Dto.Booking;

public class GetAllBookingDatesById
{
    [QueryParam] public required Guid Id { get; init; }
}