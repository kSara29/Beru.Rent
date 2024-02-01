using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Bff.Application.Contracts;

public interface ITariffService
{
    Task<ResponseModel<GuidResponse>> CreateTarifAsync(CreateTarifDto dto);
    Task<ResponseModel<bool>> DeleteTarifAsync(RequestById id);
}