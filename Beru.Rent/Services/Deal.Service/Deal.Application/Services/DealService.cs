using Common;
using Deal.Application.Contracts.Deal;
using Deal.Application.Mapper;
using Deal.Dto.Booking;

namespace Deal.Application.Services;

public class DealService: IDealService
{
    private readonly IDealRepository _dealRepository;
    
    public DealService(IDealRepository dealRepository)
    {
        _dealRepository = dealRepository;
    }

    public async Task<CreateDealResponseDto> CreateDealAsync(CreateDealRequestDto dto)
    {
        var res = await _dealRepository.CreateDealAsync(dto);
        if (res.ContainsKey(true))
        {
            return res[true].ToDtoTrue();
        }
        else
        {
            return res[false].ToDtoFalse();
        }
    }

    public async Task<ResponseModel<GetDealResponseDto>> GetDealAsync(GetDealRequestDto dto)
    {
        var res = await _dealRepository.GetDealAsync(dto);
        if (!(res.Dbeg == null))
        {
            return ResponseModel<GetDealResponseDto>.CreateSuccess(res.ToDto());
        }
        else
        {
            var errors = new List<ResponseError>();
            var errorModel = new ResponseError()
            {
                Code = "404",
                Message = "Не найдена нужная сделка"
            };
                errors.Add(errorModel);
                return ResponseModel<GetDealResponseDto>.CreateFailed(errors);
        }
        
    }

    public async Task<ResponseModel<GetDealPagesDto<GetDealResponseDto>>> GetAllDealsAsync(GetDealPagesRequestDto dto)
    {
        var deals = await _dealRepository.GetAllDealsAsync(dto);
        var result = new GetDealPagesDto<GetDealResponseDto>(deals.DealPageDto.Select(d =>
            d.ToDto()).ToList(), deals.TotalPage);

        return ResponseModel<GetDealPagesDto<GetDealResponseDto>>.CreateSuccess(result);
    }
    public async Task<ResponseModel<GetDealPagesDto<GetDealResponseDto>>> GetAllTenantDealsAsync(GetDealPagesRequestDto dto)
    {
        var deals = await _dealRepository.GetAllTenantDealsAsync(dto);
        var result = new GetDealPagesDto<GetDealResponseDto>(deals.DealPageDto.Select(d =>
            d.ToDto()).ToList(), deals.TotalPage);

        return ResponseModel<GetDealPagesDto<GetDealResponseDto>>.CreateSuccess(result);
    }

    public async Task<ResponseModel<CloseDealResponseDto>> CloseDealAsync(CloseDealRequestDto dto)
    {
        bool boolean = await _dealRepository.CloseDealAsync(dto);
        return ResponseModel<CloseDealResponseDto>.CreateSuccess(boolean.ToDtoForClose())
        ;
    }
}