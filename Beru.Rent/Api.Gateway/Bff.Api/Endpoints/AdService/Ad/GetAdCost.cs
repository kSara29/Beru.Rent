using Ad.Dto.RequestDto;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.Ad;

public class GetAdCost(IAdService service) : Endpoint<GetAdCostRequestDto, ResponseModel<DecimalResponse>>
{
    public override void Configure()
    {
        Get("/bff/ad/getAdCost");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (GetAdCostRequestDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetAdCostAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}