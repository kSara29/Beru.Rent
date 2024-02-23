using Common;
using Deal.Application.Contracts.Booking;
using Deal.Application.Mapper;
using Deal.Domain.Models;
using Deal.Dto.Booking;
using Microsoft.Extensions.Logging;

namespace Deal.Application.Services;

public class BookingService: IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly ILogger<BookingService> _logger;
    
    public BookingService(IBookingRepository bookingRepository, ILogger<BookingService> logger)
    {
        _bookingRepository = bookingRepository;
        _logger = logger;
    }   

    public async Task<bool> CancelReservationAsync(Booking booking)
    {
        return await (_bookingRepository.CancelReservationAsync(booking));
    }

    public async Task<ResponseModel<GetBookingResponseDto>> CreateBookingAsync(CreateBookingRequestDto dto)
    {
        if (dto.Dbeg < DateTime.UtcNow.AddMinutes(-1)) //Написать в сервисе + добавить ошибку и вернуть fail
        {
            var errors = new List<ResponseError>();
            var errorModel = new ResponseError()
            {
                Code = "400",
                Message = "Ввели прошедшую дату"
            };
            errors.Add(errorModel);
            
            _logger.LogWarning("Введена прошедшая дата для броинирования: {@dto}", dto);
            
            return ResponseModel<GetBookingResponseDto>.CreateFailed(errors);
        }
        var dictionary = await _bookingRepository.CreateBookingAsync(dto);
        if (dictionary.ContainsKey(true))
        {
            var booking = dictionary[true];
            
            _logger.LogInformation("Бронирование создалось успешно {@booking}", booking);
            
            return ResponseModel<GetBookingResponseDto>.CreateSuccess(booking.ToDto());
        }
        else 
        {
            var errors = new List<ResponseError>();
            var errorModel = new ResponseError()
            {
                Code = "400",
                Message = "Забронирванные даты недоступны"
            };
            errors.Add(errorModel);
            
            _logger.LogInformation("Забронирванные даты недоступны {@booking}", dictionary[false]);
            return ResponseModel<GetBookingResponseDto>.CreateFailed(errors); 
        }
        
    }

    public async Task<List<GetBookingDatesResponse>> GetBookingDatesAsync(RequestById id)
    {
        List<Booking> books = await _bookingRepository.GetBookingDatesAsync(id);
        List<GetBookingDatesResponse> list = new List<GetBookingDatesResponse>();
        foreach (var book in books) 
            list.Add(book.ToDateDto());
        
        _logger.LogInformation("Получен список забронированных дат для объявления {@id}: {@list}", id, list);
        return list;
    }

    public async Task<GetDealPagesDto<GetBookingResponseDto>> GetAllBookingsAsync(GetDealPagesRequestDto dto)
    {
        var list = await _bookingRepository.GetAllBookingsAsync(dto);
        var result = new GetDealPagesDto<GetBookingResponseDto>(list.DealPageDto.Select(ad => 
            ad.ToDto()).ToList(),list.TotalPage);
        
        return result;
    }

    public async Task<GetBookingResponseDto> GetBookingAsync(RequestById id)
    {
        var res = await _bookingRepository.GetBookingAsync(id);
        
        _logger.LogInformation("Получено бронирование по Id: {@res}", res);
        return res.ToDto();
    }

    public async Task<GetDealPagesDto<GetBookingResponseDto>> GetAllTenantBookingsAsync(GetDealPagesRequestDto dto)
    {
        var list = await _bookingRepository.GetAllTenantBookingsAsync(dto);
        var result = new GetDealPagesDto<GetBookingResponseDto>(list.DealPageDto.Select(ad => 
            ad.ToDto()).ToList(),list.TotalPage);
        
        return result;
    }

    public async Task<BoolResponseDto> CancelBookingsAsync(RequestById dto)
    {
        var list = await _bookingRepository.CancelBookingsAsync(dto);
        
        _logger.LogInformation("Хозяин товара отклонил бронирование: {@res}", list);
        return list.ToDto() ;
    }
}