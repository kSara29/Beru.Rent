using System.Security.Claims;
using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService;

public class CreateBooking(IBookingService serviceCreate) : Endpoint<CreateBookingRequestDto, ResponseModel<GetBookingResponseDto>>
{
    public override void Configure()
    {
            Post("/bff/booking/create");
    }
    
    public override async Task HandleAsync
        (CreateBookingRequestDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        request.TenantId = id;
        var response = await serviceCreate.CreateBookingAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}