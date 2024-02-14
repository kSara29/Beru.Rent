using System.Security.Claims;
using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService.Deal;

public class GetAllDeals(IDealService _service) : Endpoint<GetDealPagesRequestDto, ResponseModel<GetDealPagesDto<GetDealResponseDto>>>
{
    public override void Configure()
    {
        Get("/bff/deal/GetAllDeals/");
    }
    
    public override async Task HandleAsync
        (GetDealPagesRequestDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        request.Id = id;
        var response = await _service.GetAllDealsAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}