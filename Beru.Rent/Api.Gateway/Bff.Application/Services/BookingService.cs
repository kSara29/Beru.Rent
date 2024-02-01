using Ad.Dto.GetDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Deal.Dto.Booking;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Bff.Application.Services;

public class BookingService(
    ServiceHandler serviceHandler,
    IOptions<RequestToDealApi> jsonOptions,
    IOptions<RequestToAdApi>? jsonOptionsAd
  
    ) : IBookingService
{
    
    public async Task<ResponseModel<BoolResponseDto>> CreateBookingAsync(CreateBookingRequestDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptionsAd.Value.Url, "api/ad/GetCost/?", $"{dto.AdId}&{dto.Dbeg}&{dto.Dend}" );
        var cost = await serviceHandler.GetConnectionHandler<DecimalResponse>(url);
        dto.Cost = cost.Data.Number;
        var jsonContent = JsonConvert.SerializeObject(dto);
        var urllast = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/booking/create");
        return await serviceHandler.PostConnectionHandler<CreateBookingRequestDto, BoolResponseDto>(urllast, dto);
    }

    public async Task<ResponseModel<List<GetBookingDatesResponse>>> GetBookingDatesAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url,
            "api/booking/getbookingdates/?", $"{id.Id}");
        return await serviceHandler.GetConnectionHandler<List<GetBookingDatesResponse>>(url);;
    }

    public async Task<ResponseModel<GetBookingResponseDto>> GetBookingAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url,
            "api/booking/getbooking/?", $"{id.Id}");
        return await serviceHandler.GetConnectionHandler<GetBookingResponseDto>(url);;
    }

    public async Task<ResponseModel<List<GetAllBookingsResponseDto>>> GetAllBookingsAsync(RequestByUserId id)
    {
        var lastUrl =
            serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/booking/getallbookings/?",$"{id.Id}");
        return await serviceHandler.GetConnectionHandler<List<GetAllBookingsResponseDto>>(lastUrl);
    }
}