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
    
    public async Task<ResponseModel<GetBookingResponseDto>> CreateBookingAsync(CreateBookingRequestDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptionsAd.Value.Url, "api/ad/GetCost/");
        var cost = await serviceHandler.PostConnectionHandler<CreateBookingRequestDto, DecimalResponse>(url, dto);
        dto.Cost = cost.Data.Number;
        var urllast = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/booking/create");
        return await serviceHandler.PostConnectionHandler<CreateBookingRequestDto, GetBookingResponseDto>(urllast, dto);
    }

    public async Task<ResponseModel<List<GetBookingDatesResponse>>> GetBookingDatesAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url,
            "api/booking/getbookingdates/", $"{id.Id}");
        return await serviceHandler.GetConnectionHandler<List<GetBookingDatesResponse>>(url);;
    }

    public async Task<ResponseModel<GetBookingResponseDto>> GetBookingAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url,
            "api/booking/getbooking/", $"{id.Id}");
        return await serviceHandler.GetConnectionHandler<GetBookingResponseDto>(url);;
    }

    public async Task<ResponseModel<List<GetBookingResponseDto>>> GetAllBookingsAsync(RequestByUserId id)
    {
        var lastUrl =
            serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/booking/getallbookings/",$"{id.Id}");
        return await serviceHandler.GetConnectionHandler<List<GetBookingResponseDto>>(lastUrl);
    }

    public async Task<ResponseModel<List<GetBookingResponseDto>>> GetAllTenantBookingsAsync(RequestByUserId id)
    {
        var lastUrl =
            serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/booking/getalltenantbookings/",$"{id.Id}");
        return await serviceHandler.GetConnectionHandler<List<GetBookingResponseDto>>(lastUrl);
    }
}