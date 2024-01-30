using Ad.Application.Responses;
using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Common;

public interface ITarifService
{
    Task<ResponseModel<GuidResponse>> CreateTarifAsync(CreateTarifDto dto);
    Task<ResponseModel<StringResponse>> DeleteTarifAsync(Guid id);
}