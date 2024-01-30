using Common;
using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
using FastEndpoints;
namespace Deal.Api.Endpoints;

public class GetBookingDates(IBookingService service): Endpoint<RequestById, ResponseModel<List<GetBookingDatesResponse>>>    
{
    public override void Configure()
    {
        Get("api/booking/getbookingdates/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestById id, CancellationToken ct)
    {
        var list = await service.GetBookingDatesAsync(id);
        var results = ResponseModel<List<GetBookingDatesResponse>>.CreateSuccess(list);
        await SendAsync(results, cancellation: ct);;
    }
}