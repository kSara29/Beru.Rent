using Ad.Application.Contracts.Ad;
using Ad.Application.Responses;

namespace Ad.Application.Contracts.Address;

public interface IAddressService<T, TK>
{
    Task<BaseApiResponse<Guid>> CreateAsync(T dto);
    Task<BaseApiResponse<string>> RemoveAsync(Guid id);
    Task<BaseApiResponse<TK?>> GetAsync(Guid id);
}