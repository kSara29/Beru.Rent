using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Responses;
using Ad.Dto.ResponseDto;
using Common;

namespace Ad.Application.Contracts.TimeUnit;

public interface ITimeUnitService
{
    Task<ResponseModel<GuidResponse>> CreateAsync(CreateTimeUnitDto dto);
    Task<ResponseModel<TimeUnitDto?>> GetAsync(Guid id);
    Task<ResponseModel<List<TimeUnitDto?>>> GetAllAsync();
}