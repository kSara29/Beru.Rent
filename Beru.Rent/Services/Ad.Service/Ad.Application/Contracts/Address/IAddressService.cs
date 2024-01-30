using Ad.Application.Contracts.Ad;
using Ad.Application.Responses;
using Ad.Dto.ResponseDto;
using Common;

namespace Ad.Application.Contracts.Address;

public interface IAddressService<T, TK>
{
    Task<ResponseModel<GuidResponse>> CreateAsync(T dto);
    Task<ResponseModel<StringResponse>> RemoveAsync(Guid id);
    Task<ResponseModel<TK?>> GetAsync(Guid id);
}