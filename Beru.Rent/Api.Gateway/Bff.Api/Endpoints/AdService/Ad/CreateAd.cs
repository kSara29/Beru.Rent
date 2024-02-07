using System.Security.Claims;
using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Bff.Api.Endpoints.AdService;


public class CreateAd(IAdService service) : Endpoint<CreateAdDto, ResponseModel<GuidResponse>>
{
    public override void Configure()
    {
        Post("/bff/ad/create");
        
    }
    
    public override async Task HandleAsync
        (CreateAdDto? request, CancellationToken ct)
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.CreateAdAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}