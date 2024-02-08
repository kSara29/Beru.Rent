using Common;
using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class GetAllTenantBookings(IBookingService _service): Endpoint<GetDealPagesRequestDto, ResponseModel<GetDealPagesDto<GetBookingResponseDto>>>
{
    public override void Configure()
    {
        Get("api/booking/getalltenantbookings/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetDealPagesRequestDto dto, CancellationToken ct)
    {
        var list = await _service.GetAllTenantBookingsAsync(dto);
        var result = ResponseModel<GetDealPagesDto<GetBookingResponseDto>>.CreateSuccess(list);
        await SendAsync(result, cancellation: ct);
    }
}