using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.File;

public class GetFileById
    (IFileService service) : Endpoint<RequestById, ResponseModel<byte[]>>
{
    public override void Configure()
    {
        Get("/bff/file/getById");
        AllowAnonymous();
    }

    public override async Task HandleAsync
        (RequestById request,CancellationToken ct)
    {
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetFileAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}
