using Common;
using Deal.Application.Contracts.Deal;
using Deal.Application.Mapper;
using Deal.Application.Message;
using Deal.Dto.Booking;

namespace Deal.Application.Services;

public class DealService: IDealService
{
    private readonly IDealRepository _dealRepository;
    private readonly IMessagePublisher _messagePublisher;
    
    public DealService(IDealRepository dealRepository, IMessagePublisher messagePublisher)
    {
        _dealRepository = dealRepository;
        _messagePublisher = messagePublisher;
    }

    public async Task<ResponseModel<CreateDealResponseDto>> CreateDealAsync(CreateDealRequestDto dto)
    {
        var res = await _dealRepository.CreateDealAsync(dto);
        var chatId = await
            _messagePublisher.PublishDealCreatedMessageAsync(new ChatCreatedMessage() { Users = res.Data.Participant });

        var createDealResponse = await _dealRepository.UpdateDealAsync(chatId, res.Data.DealId);
        
        return createDealResponse;
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