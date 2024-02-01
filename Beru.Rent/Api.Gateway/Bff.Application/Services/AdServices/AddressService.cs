using Ad.Api.Request;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
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
        throw new NotImplementedException();
    }

    public async Task<ResponseModel<StringResponse>> RemoveAddressAsync(RequestById id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseModel<AddressExtraDto?>> GetAddressAsync(RequestById id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseModel<List<string>>> SuggestAddress(QueryModel model)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/address/suggestions");
        return await serviceHandler.PostConnectionHandler<QueryModel, List<string>>(url, model);
    }
}