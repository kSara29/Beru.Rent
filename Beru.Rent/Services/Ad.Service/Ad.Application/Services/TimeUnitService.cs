using Ad.Application.Contracts.TimeUnit;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Mapper;
using Ad.Application.Responses;
using Ad.Dto.ResponseDto;
using Common;

namespace Ad.Application.Services;

public class TimeUnitService : ITimeUnitService
{
    private readonly ITimeUnitRepository _repository;

    public TimeUnitService(ITimeUnitRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResponseModel<GuidResponse>> CreateAsync(CreateTimeUnitDto dto)
    {
        var result = await _repository.CreateAsync(dto.ToDomain());
        return ResponseModel<GuidResponse>.CreateSuccess(new GuidResponse
        {
            Id = result
        });
    }

    public async Task<ResponseModel<TimeUnitDto?>> GetAsync(Guid id)
    {
        var result = await _repository.GetAsync(id);
        if (result != null)
        {
            return ResponseModel<TimeUnitDto?>.CreateSuccess(result.ToDto());
        }
        var errors = new List<ResponseError>();
        var errorModel = new ResponseError
        {
            Code = "404",
            Message = "С таким Id временного периода не найдено"
        };
        errors.Add(errorModel);
        return ResponseModel<TimeUnitDto?>.CreateFailed(errors);  
    }

    public async Task<ResponseModel<List<TimeUnitDto?>>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        return ResponseModel<List<TimeUnitDto>?>.CreateSuccess(result.Select(t=>t.ToDto()).ToList());
    }
}