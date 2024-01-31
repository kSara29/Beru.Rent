using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Bff.Application.Services;

public class FileService(ServiceHandler<byte[]?> serviceHandlerGetFile,
    ServiceHandler<StringResponse> serviceHandlerStringResponse,
    IOptions<RequestToAdApi> jsonOptions
    ):IFileService
{
    public async Task<ResponseModel<StringResponse>> UploadFileAsync(CreateFileDto dto)
    {
        var jsonContent = JsonConvert.SerializeObject(dto);
        var url = serviceHandlerStringResponse.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/file/upload");
        return await serviceHandlerStringResponse.PostConnectionHandler(url, jsonContent);
    }

    public async Task<ResponseModel<StringResponse>> RemoveFileAsync(RequestById id)
    {
        var url = serviceHandlerStringResponse.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/file/delete/", id.Id.ToString());
        var result = await serviceHandlerStringResponse.GetConnectionHandler(url);
        return result;
    }

    public async Task<ResponseModel<byte[]>> GetFileAsync(RequestById id)
    {
        var url = serviceHandlerGetFile.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/file/get/", id.Id.ToString());
        var result = await serviceHandlerGetFile.GetConnectionHandler(url);
        return result;
    }
}