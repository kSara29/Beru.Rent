using Ad.Api.Request;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.Address;

public class SuggestAddress(IAddressService service) : Endpoint<QueryModel, ResponseModel<List<string>>>
{
    public override void Configure()
    {
        Get("/bff/address/suggestions");
        AllowAnonymous();
    }

    public override async Task HandleAsync
        ([Microsoft.AspNetCore.Mvc.FromBody]QueryModel request,CancellationToken ct)
    {
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.SuggestAddress(request);
        await SendAsync(response, cancellation: ct);
    }
}
