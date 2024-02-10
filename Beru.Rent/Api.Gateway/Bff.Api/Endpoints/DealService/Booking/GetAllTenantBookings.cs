using System.Security.Claims;
using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService;

public class GetAllTenantBookings(IBookingService _service) : Endpoint<GetDealPagesRequestDto, ResponseModel<GetDealPagesDto<GetBookingResponseDto>>>
{
    public override void Configure()
    {
        Get("/bff/booking/getalltenantbookings/");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (GetDealPagesRequestDto? dto, CancellationToken ct)
    { 
        if (dto is null) await SendAsync(null!, cancellation: ct);
        var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        dto.Id = id;
        var response = await _service.GetAllTenantBookingsAsync(dto!);
        await SendAsync(response, cancellation: ct);
    }
}