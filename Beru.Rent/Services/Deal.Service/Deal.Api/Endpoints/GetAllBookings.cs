using Deal.Api.DTO.Booking;
using Deal.Application.Contracts.Booking;
using Deal.Application.DTO.Booking;
using FastEndpoints;
namespace Deal.Api.Endpoints;

public class GetAllBookings(IBookingService service): Endpoint<GetAllBookingDto>
{
    public override void Configure()
    {
        Post("api/booking/getallbookings");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllBookingDto model, CancellationToken ct)
    {
        var results = await service.GetAllBookingsAsync(model.AdId);
        await SendAsync(results, cancellation: ct);
    }
}