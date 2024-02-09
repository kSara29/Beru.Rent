using Ad.Application.DTO.GetDtos;
using Ad.Dto.RequestDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService;

public class GetMainPageFindAds(IAdService service) : Endpoint<FindMainPageRequestDto, ResponseModel<GetMainPageDto<AdMainPageDto>>>
{
    public override void Configure()
    {
        Get("/bff/ad/getMainPageFindAds");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (FindMainPageRequestDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetAllFindAdAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}