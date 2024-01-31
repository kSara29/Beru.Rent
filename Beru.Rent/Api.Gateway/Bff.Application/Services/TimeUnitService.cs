using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Bff.Application.Services;

public class TimeUnitService(
    ServiceHandler<GuidResponse> serviceHandlerGuid,
    ServiceHandler<List<TimeUnitDto?>> serviceHandlerListTimeUnits,
    ServiceHandler<TimeUnitDto?> serviceHandlerTimeUnitDto,
    IOptions<RequestToAdApi> jsonOptions) : ITimeUnitService
{
    public async Task<ResponseModel<GuidResponse>> CreateAsync(CreateTimeUnitDto dto)
    {
        var jsonContent = JsonConvert.SerializeObject(dto);
        var url = serviceHandlerGuid.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/timeunit/post/create");
        return await serviceHandlerGuid.PostConnectionHandler(url, jsonContent);
    }

    public async Task<ResponseModel<TimeUnitDto?>> GetAsync(RequestById id)
    {
        var url = serviceHandlerTimeUnitDto.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/timeunit/get/", id.Id.ToString());
        var result = await serviceHandlerTimeUnitDto.GetConnectionHandler(url);
        return result;
    }

    public async Task<ResponseModel<List<TimeUnitDto?>>> GetAllAsync()
    {
        var url = serviceHandlerListTimeUnits.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/timeunit/get/", null);
        var result = await serviceHandlerListTimeUnits.GetConnectionHandler(url);
        return result;
    }
}