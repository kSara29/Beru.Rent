using System.Runtime.InteropServices.JavaScript;
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
        DateArray[] dateTimes = new DateArray[results.Length];
        for (int i = 0; i < results.Length; i++)
        {
            dateTimes[i].from = results[i,0];
            dateTimes[i].to = results[i,1];
        }
        /*
           [[дата начала, дата конца],
            [дата начала, дата конца],
            [дата начала, дата конца]]

            [[[дата начала],[дата конца]],
             [[дата начала],[дата конца]],
             [[дата начала],[дата конца]]]

           */
        await SendAsync(dateTimes, cancellation: ct);
    }
}