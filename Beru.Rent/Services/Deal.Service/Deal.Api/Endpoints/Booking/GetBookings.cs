using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class GetBookings(IBookingService _service): Endpoint<Guid>
{
    public override void Configure()
    {
        Post("api/booking/getbookings/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid id, CancellationToken ct)
    {
        var result = await _service.GetBookingsAsync(id);
        await SendAsync(result, cancellation: ct);
    }
}