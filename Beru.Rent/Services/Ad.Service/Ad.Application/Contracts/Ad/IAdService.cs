

using Ad.Api.DTO;
using Ad.Application.Responses;

public interface IAdService
{
    Task<BaseApiResponse<Guid>> CreateAdAsync(CreateAdDto ad);
}