using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Bff.Application.Contracts;

public interface ITimeUnitService
{
    Task<ResponseModel<GuidResponse>> CreateAsync(CreateTimeUnitDto dto);
    Task<ResponseModel<TimeUnitDto?>> GetAsync(RequestById id);
    Task<ResponseModel<List<TimeUnitDto?>>> GetAllAsync();
}