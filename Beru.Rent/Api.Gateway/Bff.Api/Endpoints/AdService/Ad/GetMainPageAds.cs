using Ad.Application.DTO.GetDtos;
using Ad.Dto.RequestDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService;

public class GetMainPageAds(IAdService service) : Endpoint<MainPageRequestDto, ResponseModel<GetMainPageDto<AdMainPageDto>>>
{
    public override void Configure()
    {
        Get("/bff/ad/getMainPageAds");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (MainPageRequestDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetAllAdAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}
