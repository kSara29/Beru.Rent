using Ad.Dto.CreateDtos;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;
namespace Bff.Api.Endpoints.AdService;


public class CreateAd(IAdService service) : Endpoint<CreateAdDto, ResponseModel<Guid>>
{
    public override void Configure()
    {
        Post("/bff/user/createUser");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CreateAdDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.CreateAdAsync()
        await SendAsync(response, cancellation: ct);
    }
}