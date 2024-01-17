using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Responses;

namespace Ad.Application.Contracts.TimeUnit;

public interface ITimeUnitService
{
    Task<BaseApiResponse<Guid>> CreateAsync(CreateTimeUnitDto dto);
    Task<BaseApiResponse<TimeUnitDto?>> GetAsync(Guid id);
    Task<BaseApiResponse<List<TimeUnitDto?>>> GetAllAsync();
}