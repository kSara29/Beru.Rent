using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Bff.Application.Services;

public class FileService(ServiceHandler serviceHandler,
    IOptions<RequestToAdApi> jsonOptions
    ):IFileService
{
    public async Task<ResponseModel<StringResponse>> UploadFileAsync(CreateFileDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/file/upload");
        return await serviceHandler.PostConnectionHandler<CreateFileDto, StringResponse>(url, dto);
    }

    public async Task<ResponseModel<StringResponse>> RemoveFileAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/file/delete/", id.Id.ToString());
        var result = await serviceHandler.GetConnectionHandler<StringResponse>(url);
        return result;
    }

    public async Task<ResponseModel<byte[]>> GetFileAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/file/get/", id.Id.ToString());
        var result = await serviceHandler.GetConnectionHandler<byte[]>(url);
        return result;
    }
}