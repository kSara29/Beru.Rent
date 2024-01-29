using Ad.Application.DTO.GetDtos;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.TimeUnit;

public class GetAllTimeUnits(ITimeUnitService service) : Endpoint<EmptyRequest, ResponseModel<List<TimeUnitDto?>>>
{
    public override void Configure()
    {
        Get("/bff/timeunit/get");
        AllowAnonymous();
    }

    public override async Task HandleAsync
        (EmptyRequest request,CancellationToken ct)
    {
        var response = await service.GetAllAsync();
        await SendAsync(response, cancellation: ct);
    }
}
