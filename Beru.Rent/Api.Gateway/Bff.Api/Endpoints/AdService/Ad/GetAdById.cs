using Ad.Dto.CreateDtos;
using Ad.Dto.GetDtos;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService;

public class GetAdById(IAdService service) : Endpoint<RequestById, ResponseModel<AdDto>>
{
    public override void Configure()
    {
        Get("/bff/ad/getById");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (RequestById? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetAdAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}