using Common;
using Deal.Application.Contracts.Deal;
using Deal.Application.Mapper;
using Deal.Application.Message;
using Deal.Dto.Booking;
using Microsoft.Extensions.Logging;

namespace Deal.Application.Services;

public class DealService: IDealService
{
    private readonly IDealRepository _dealRepository;
    private readonly IMessagePublisher _messagePublisher;
    private readonly ILogger<DealService> _logger;
    
    public DealService(IDealRepository dealRepository, IMessagePublisher messagePublisher, ILogger<DealService> logger)
    {
        _dealRepository = dealRepository;
        _messagePublisher = messagePublisher;
        _logger = logger;
    }

    public async Task<ResponseModel<CreateDealResponseDto>> CreateDealAsync(CreateDealRequestDto dto)
    {
        var res = await _dealRepository.CreateDealAsync(dto);
        _logger.LogInformation("Создалась сделка: {@res}", res);
        
        Guid chatId=Guid.Empty;
        try
        {
              chatId = await
                _messagePublisher.PublishDealCreatedMessageAsync(new ChatCreatedMessage() { Users = res.Data.Participant });
              _logger.LogInformation("RabbitMQ отправлено сообщение по созданию чата");

        }
        catch(Exception e)
        {
            _logger.LogError("RabbitMQ не удалось отправить сообщение по созданию чата");
            Console.WriteLine(e.Message);
        }
        var createDealResponse = await _dealRepository.UpdateDealAsync(chatId, res.Data.DealId);
        
        return createDealResponse;
    }

    public async Task<ResponseModel<GetDealResponseDto>> GetDealAsync(GetDealRequestDto dto)
    {
        var res = await _dealRepository.GetDealAsync(dto);
        if (!(res.Dbeg == null))
        {
            _logger.LogInformation("Найдена сделка: {@res}", res);
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
                
                _logger.LogInformation("Сделка не найдена: {@res}", res);
                return ResponseModel<GetDealResponseDto>.CreateFailed(errors);
        }
        
    }

    public async Task<ResponseModel<GetDealPagesDto<GetDealResponseDto>>> GetAllDealsAsync(GetDealPagesRequestDto dto)
    {
        var deals = await _dealRepository.GetAllDealsAsync(dto);
        var result = new GetDealPagesDto<GetDealResponseDto>(deals.DealPageDto.Select(d =>
            d.ToDto()).ToList(), deals.TotalPage);

        _logger.LogInformation("Получен список всех сделок {@res}", result);
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