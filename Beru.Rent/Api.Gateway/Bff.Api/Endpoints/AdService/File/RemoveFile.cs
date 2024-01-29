using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.File;

public class RemoveFile(IFileService service) : Endpoint<RequestById, ResponseModel<StringResponse>>
{
    public override void Configure()
    {
        Post("/bff/file/deleteById");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (RequestById? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.RemoveFileAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}