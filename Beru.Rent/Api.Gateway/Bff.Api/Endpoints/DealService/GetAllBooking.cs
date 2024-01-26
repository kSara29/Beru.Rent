using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService;

public class GetAllBooking(IDealServiceGet serviceGet) : Endpoint<ResponseModel<GetAllBookingDto>>
{
    public override void Configure()
    {
        Get("/bff/deal/getAllBookings");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (ResponseModel<GetAllBookingDto> req, CancellationToken ct)
    {
        var response = await serviceGet.GetAllBookingAsync();
        await SendAsync(response, cancellation: ct);
    }
}