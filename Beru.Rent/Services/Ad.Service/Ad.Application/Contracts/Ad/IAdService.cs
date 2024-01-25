using Ad.Application.Responses;
using Ad.Dto;

namespace Ad.Application.Contracts.Ad;

public interface IAdService
{
    Task<BaseApiResponse<Guid>> CreateAdAsync(CreateAdDto ad);
}