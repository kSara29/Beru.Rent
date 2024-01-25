using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class CreateBooking(IBookingService service) : Endpoint<CreateBookingDto,object>
{
    public override void Configure()
    {
        Post("/api/booking/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBookingDto model, CancellationToken ct)
    {
        var results = await service.CreateBookingAsync(model);
        await SendAsync(results, cancellation: ct);
    }
}