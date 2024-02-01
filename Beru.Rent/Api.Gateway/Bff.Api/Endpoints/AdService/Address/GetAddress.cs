using Ad.Application.DTO.GetDtos;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.Address;

public class GetAddress(IAddressService service): Endpoint<RequestById, ResponseModel<AddressExtraDto>>
{
    public override void Configure()
    {
        Get("/bff/address/get");
        AllowAnonymous();
    }

    public override async Task HandleAsync
        (RequestById request,CancellationToken ct)
    {
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetAddressAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}