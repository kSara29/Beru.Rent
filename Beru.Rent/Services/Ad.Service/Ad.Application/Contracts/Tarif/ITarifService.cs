

using Ad.Api.DTO.Tarif;
using Ad.Application.Responses;

public interface ITarifService
{
    Task<BaseApiResponse<Guid>> CreateTarifAsync(CreateTarifDto dto);
    Task<BaseApiResponse<bool>> DeleteTarifAsync(Guid id);
}