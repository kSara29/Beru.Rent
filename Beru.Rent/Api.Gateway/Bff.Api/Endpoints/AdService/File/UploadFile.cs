using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Common;
using FastEndpoints;

namespace Bff.Api.Endpoints.AdService.File;

public class UploadFile(IFileService service) : Endpoint<CreateFileDto, ResponseModel<StringResponse>>
{
    public override void Configure()
    {
        Post("/bff/file/upload");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CreateFileDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.UploadFileAsync(request);
        await SendAsync(response, cancellation: ct);
    }
}