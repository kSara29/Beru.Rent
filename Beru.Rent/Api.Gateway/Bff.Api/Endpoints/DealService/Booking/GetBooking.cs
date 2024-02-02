using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService;

public class GetBooking(IBookingService _service) : Endpoint<RequestById, ResponseModel<GetBookingResponseDto>>
{
    public override void Configure()
    {
        Get("/bff/booking/getbooking/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (RequestById? id, CancellationToken ct)
    { 
        if (id is null) await SendAsync(null!, cancellation: ct);
        var response = await _service.GetBookingAsync(id!);
        await SendAsync(response, cancellation: ct);
    }
}