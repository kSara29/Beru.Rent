using Ad.Application.Contracts.TimeUnit;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Mapper;
using Ad.Application.Responses;

namespace Ad.Application.Services;

public class TimeUnitService : ITimeUnitService
{
    private readonly ITimeUnitRepository _repository;

    public TimeUnitService(ITimeUnitRepository repository)
    {
        _repository = repository;
    }
    public async Task<BaseApiResponse<Guid>> CreateAsync(CreateTimeUnitDto dto)
    {
        var result = await _repository.CreateAsync(dto.ToDomain());
        return new BaseApiResponse<Guid>(result);
    }

    public async Task<BaseApiResponse<TimeUnitDto?>> GetAsync(Guid id)
    {
        var result = await _repository.GetAsync(id);
        return new BaseApiResponse<TimeUnitDto?>(result.ToDto());
    }

    public async Task<BaseApiResponse<List<TimeUnitDto?>>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        return new BaseApiResponse<List<TimeUnitDto>?>(result.Select(t=>t.ToDto()).ToList());
    }
}