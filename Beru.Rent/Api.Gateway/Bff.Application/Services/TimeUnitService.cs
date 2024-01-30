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
    ServiceHandler serviceHandler,
    IOptions<RequestToAdApi> jsonOptions) : ITimeUnitService
{
    public async Task<ResponseModel<GuidResponse>> CreateAsync(CreateTimeUnitDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/timeunit/post/create");
        return await serviceHandler.PostConnectionHandler<CreateTimeUnitDto, GuidResponse>(url, dto);
    }

    public async Task<ResponseModel<TimeUnitDto?>> GetAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/timeunit/get/", id.Id.ToString());
        var result = await serviceHandler.GetConnectionHandler<TimeUnitDto>(url);
        return result;
    }

    public async Task<ResponseModel<List<TimeUnitDto?>>> GetAllAsync()
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/timeunit/get/", null);
        var result = await serviceHandler.GetConnectionHandler<List<TimeUnitDto>>(url);
        return result;
    }
}