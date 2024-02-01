using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.Address;

public class DelereAddress(IAddressService service): Endpoint<RequestById, ResponseModel<StringResponse>>
{
    public override void Configure()
    {
        Post("/bff/address/delete");
        AllowAnonymous();
    }

    public override async Task HandleAsync
        (RequestById request,CancellationToken ct)
    {
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.RemoveAddressAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}