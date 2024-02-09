using Ad.Application.DTO.CreateDtos;
using Ad.Dto.RequestDto;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.Address;

public class CreateAddress(IAddressService service): Endpoint<CreateAddressExtraDto, ResponseModel<GuidResponse>>
{
    public override void Configure()
    {
        Post("/bff/address/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync
        (CreateAddressExtraDto request,CancellationToken ct)
    {
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.CreateAddressAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}