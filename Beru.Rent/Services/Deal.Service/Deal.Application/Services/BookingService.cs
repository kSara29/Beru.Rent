using Common;
using Deal.Application.Contracts.Booking;
using Deal.Application.Mapper;
using Deal.Domain.Models;
using Deal.Dto.Booking;

namespace Deal.Application.Services;

public class BookingService: IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
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
            return ResponseModel<GetBookingResponseDto>.CreateFailed(errors);
        }
        var dictionary = await _bookingRepository.CreateBookingAsync(dto);
        if (dictionary.ContainsKey(true))
        {
            var booking = dictionary[true];
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
            return ResponseModel<GetBookingResponseDto>.CreateFailed(errors); 
        }
        
    }

    public async Task<List<GetBookingDatesResponse>> GetBookingDatesAsync(RequestById id)
    {
        List<Booking> books = await _bookingRepository.GetBookingDatesAsync(id);
        List<GetBookingDatesResponse> list = new List<GetBookingDatesResponse>();
        foreach (var book in books) 
            list.Add(book.ToDateDto());
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
        return list.ToDto() ;
    }
}