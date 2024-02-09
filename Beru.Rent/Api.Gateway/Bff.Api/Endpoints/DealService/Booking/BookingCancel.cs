using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService;


public class BookingCancel(IBookingService service) : Endpoint<RequestById, ResponseModel<BoolResponseDto>>
{
    public override void Configure()
    {
        Get("/bff/booking/cancel/");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (RequestById? dto, CancellationToken ct)
    { 
        if (dto is null) await SendAsync(null!, cancellation: ct);
        var response = await service.BookingCancelAsync(dto!);
        await SendAsync(response, cancellation: ct);
    }
}