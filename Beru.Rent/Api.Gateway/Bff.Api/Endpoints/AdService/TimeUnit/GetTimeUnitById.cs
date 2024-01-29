using Ad.Application.DTO.GetDtos;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.TimeUnit;

public class GetTimeUnitById(ITimeUnitService service) : Endpoint<RequestById, ResponseModel<TimeUnitDto?>>
{
    public override void Configure()
    {
        Get("/bff/timeunit/getById");
        AllowAnonymous();
    }

    public override async Task HandleAsync
        (RequestById request, CancellationToken ct)
    {
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}