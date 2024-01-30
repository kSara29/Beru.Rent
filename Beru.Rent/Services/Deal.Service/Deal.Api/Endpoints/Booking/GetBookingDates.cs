using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
using FastEndpoints;
namespace Deal.Api.Endpoints;

public class GetBookingDates(IBookingService service): Endpoint<Guid, DateArray[]>    
{
    public override void Configure()
    {
        Get("api/booking/getbookingdates/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid id, CancellationToken ct)
    {
        
        
        var results = await service.GetBookingDatesAsync(id);
        if (results != null)
        {
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
        else
        {
            await SendAsync(new DateArray[0], cancellation: ct);
        }
    }
}