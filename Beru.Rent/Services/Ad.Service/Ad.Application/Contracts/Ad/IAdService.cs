

using Ad.Api.DTO;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Responses;

public interface IAdService
{
    Task<BaseApiResponse<Guid>> CreateAdAsync(CreateAdDto ad);
    Task<BaseApiResponse<AdDto>> GetAdAsync(Guid id);
}