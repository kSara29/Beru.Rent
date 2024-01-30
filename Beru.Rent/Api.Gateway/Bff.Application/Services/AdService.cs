using Ad.Application.DTO.GetDtos;
using Ad.Dto.CreateDtos;
using Ad.Dto.GetDtos;
using Ad.Dto.RequestDto;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using User.Dto;

namespace Bff.Application.Services;

public class AdService(
    ServiceHandler<GuidResponse> serviceHandlerGuid, 
    ServiceHandler<AdDto> serviceHandlerAdDto, 
    ServiceHandler<GetMainPageDto<AdMainPageDto>> serviceHandlerMainAdDto, 
    ServiceHandler<DecimalResponse> serviceHandlerDecimal, 
    ServiceHandler<StringResponse> serviceHandlerString, 
    IOptions<RequestToAdApi> jsonOptions)
    :IAdService

{
    public async Task<ResponseModel<GuidResponse>> CreateAdAsync(CreateAdDto ad)
    {
        var jsonContent = JsonConvert.SerializeObject(ad);
        var url = serviceHandlerGuid.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/ad/create");
        return await serviceHandlerGuid.PostConnectionHandler(url, jsonContent);
    }


    public async Task<ResponseModel<AdDto>> GetAdAsync(RequestById id)
    {
        var url = serviceHandlerAdDto.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/ad/get/", id.Id.ToString());
        var result = await serviceHandlerAdDto.GetConnectionHandler(url);
        return result;
    }
            

    public async Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllAdAsync(MainPageRequestDto requestDto)
    {
        var url = serviceHandlerMainAdDto.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/ad/get/?", $"page={requestDto.Page}&sortdate={requestDto.SortDate}&sortprice={requestDto.SortPrice}&cat={requestDto.CategoryName}");
        var result = await serviceHandlerMainAdDto.GetConnectionHandler(url);
        return result;
    }

    public Task<ResponseModel<DecimalResponse>> GetCostAsync(RequestById adId, DateTime ebeg, DateTime dend)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<StringResponse>> GetOwnerIdAsync(RequestById adId)
    {
        throw new NotImplementedException();
    }
}