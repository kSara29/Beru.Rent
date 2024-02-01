using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService;

public class GetBookingDates(IBookingService _service) : Endpoint<RequestById, ResponseModel<List<GetBookingDatesResponse>>>
{
    public override void Configure()
    {
        Get("/bff/deal/getbookingdates/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (RequestById? id, CancellationToken ct)
    { 
        if (id is null) await SendAsync(null!, cancellation: ct);
        var response = await _service.GetBookingDatesAsync(id!);
        await SendAsync(response, cancellation: ct);
    }
}