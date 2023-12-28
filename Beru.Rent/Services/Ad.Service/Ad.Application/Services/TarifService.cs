using Ad.Api.DTO.Tarif;
using Ad.Api.Mapper;
using Ad.Application.Responses;


namespace Ad.Application.Services;

public class TarifService : ITarifService
{
    private readonly ITarifRepository _tarifRepository;

    public TarifService(ITarifRepository tarifRepository)
    {
        _tarifRepository = tarifRepository;
    }

    public async Task<BaseApiResponse<Guid>> CreateTarifAsync(CreateTarifDto dto)
    {
        var result = await _tarifRepository.CreateTarifAsync(dto.ToDomain());
        return new BaseApiResponse<Guid>(result);

    }

    public async Task<BaseApiResponse<bool>> DeleteTarifAsync(Guid id)
    {
        var result = await _tarifRepository.DeleteTarifAsync(id);
        return new BaseApiResponse<bool>(result);
    }
}