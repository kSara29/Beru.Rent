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

    public async Task<ResponseModel<List<GetAllDealsResponseDto>>> GetAllDealsAsync(RequestByUserId id)
    {
        var deals = await _dealRepository.GetAllDealsAsync(id);
        List<GetAllDealsResponseDto> lists = new List<GetAllDealsResponseDto>();
        foreach (var deal in deals)
        {
            lists.Add(deal.ToDtoDeals());
        }

        return ResponseModel<List<GetAllDealsResponseDto>>.CreateSuccess(lists);
    }
    public async Task<ResponseModel<List<GetAllDealsResponseDto>>> GetAllTenantDealsAsync(RequestByUserId id)
    {
        var deals = await _dealRepository.GetAllTenantDealsAsync(id);
        List<GetAllDealsResponseDto> lists = new List<GetAllDealsResponseDto>();
        foreach (var deal in deals)
        {
            lists.Add(deal.ToDtoDeals());
        }

        return ResponseModel<List<GetAllDealsResponseDto>>.CreateSuccess(lists);
    }
}