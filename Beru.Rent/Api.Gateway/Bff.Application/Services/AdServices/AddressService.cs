using Ad.Api.Request;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Dto.RequestDto;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Microsoft.Extensions.Options;

namespace Bff.Application.Services;

public class AddressService(
    ServiceHandler serviceHandler,
    IOptions<RequestToAdApi> jsonOptions):IAddressService
{
    public async Task<ResponseModel<GuidResponse>> CreateAddressAsync(CreateAddressExtraDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/address/extra/create");
        return await serviceHandler.PostConnectionHandler<CreateAddressExtraDto, GuidResponse>(url, dto);
    }

    public async Task<ResponseModel<StringResponse>> RemoveAddressAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/address/extra/delete/", id.Id.ToString());
        var result = await serviceHandler.GetConnectionHandler<StringResponse>(url);
        return result;
    }

    public async Task<ResponseModel<AddressExtraDto?>> GetAddressAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/address/extra/get/", id.Id.ToString());
        var result = await serviceHandler.GetConnectionHandler<AddressExtraDto?>(url);
        return result;
    }

    public async Task<ResponseModel<List<string>>> SuggestAddress(QueryModel model)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/address/suggestions");
        return await serviceHandler.PostConnectionHandler<QueryModel, List<string>>(url, model);
    }
}