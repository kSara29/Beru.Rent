using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService;

public class GetAllBookings(IBookingService _service) : Endpoint<GetDealPagesRequestDto, ResponseModel<GetDealPagesDto<GetBookingResponseDto>>>
{
    public override void Configure()
    {
        Get("/bff/booking/getallbookings/");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (GetDealPagesRequestDto? dto, CancellationToken ct)
    { 
        if (dto is null) await SendAsync(null!, cancellation: ct);
        var response = await _service.GetAllBookingsAsync(dto!);
        await SendAsync(response, cancellation: ct);
    }
}