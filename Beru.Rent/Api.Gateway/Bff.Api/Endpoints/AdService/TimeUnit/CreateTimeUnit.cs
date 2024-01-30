using Ad.Application.DTO.CreateDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.TimeUnit;

public class CreateTimeUnit(ITimeUnitService service) : Endpoint<CreateTimeUnitDto, ResponseModel<GuidResponse>>
{
    public override void Configure()
    {
        Post("/bff/timeunit/create");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CreateTimeUnitDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.CreateAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}