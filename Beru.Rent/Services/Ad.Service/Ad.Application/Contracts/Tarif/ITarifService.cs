using Ad.Application.Responses;
using Ad.Dto.CreateDtos;

public interface ITarifService
{
    Task<BaseApiResponse<Guid>> CreateTarifAsync(CreateTarifDto dto);
    Task<BaseApiResponse<bool>> DeleteTarifAsync(Guid id);
}