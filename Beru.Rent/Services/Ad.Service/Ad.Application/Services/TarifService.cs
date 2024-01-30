using Ad.Api.Mapper;
using Ad.Application.Responses;
using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Common;


namespace Ad.Application.Services;

public class TarifService : ITarifService
{
    private readonly ITarifRepository _tarifRepository;

    public TarifService(ITarifRepository tarifRepository)
    {
        _tarifRepository = tarifRepository;
    }

    public async Task<ResponseModel<GuidResponse>> CreateTarifAsync(CreateTarifDto dto)
    {
        var result = await _tarifRepository.CreateTarifAsync(dto.ToDomain());
        return ResponseModel<GuidResponse>.CreateSuccess(new GuidResponse
        {
            Id = result
        });

    }

    public async Task<ResponseModel<StringResponse>> DeleteTarifAsync(Guid id)
    {
        var result = await _tarifRepository.DeleteTarifAsync(id);
        return ResponseModel<StringResponse>.CreateSuccess(new StringResponse
        {
            Text = result.ToString()
        });
    }
}