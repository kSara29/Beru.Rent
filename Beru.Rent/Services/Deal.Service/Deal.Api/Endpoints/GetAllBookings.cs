using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
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
        DateArray[] dateTimes = new DateArray[results.Length/2];
        for (int i = 0; i < results.Length/2; i++)
        {
            dateTimes[i] = new DateArray()
            {
                from = results[i, 0],
                to = results[i, 1]
            };
        }
        await SendAsync(dateTimes, cancellation: ct);
    }
}