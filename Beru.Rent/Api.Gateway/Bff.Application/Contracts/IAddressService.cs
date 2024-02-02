using Ad.Api.Request;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Bff.Application.Contracts;

public interface IAddressService
{
    Task<ResponseModel<GuidResponse>> CreateAddressAsync(CreateAddressExtraDto dto);
    Task<ResponseModel<StringResponse>> RemoveAddressAsync(RequestById id);
    Task<ResponseModel<AddressExtraDto?>> GetAddressAsync(RequestById id);
    Task<ResponseModel<List<string>>> SuggestAddress(QueryModel model);
}