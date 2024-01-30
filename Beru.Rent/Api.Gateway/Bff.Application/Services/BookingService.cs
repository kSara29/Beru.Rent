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
    ServiceHandler<DecimalResponse> serviceHandlerDecimal,
    ServiceHandler<BoolResponseDto> serviceHandlerBoolResponseDto,
    IOptions<RequestToDealApi> jsonOptions,
    IOptions<RequestToAdApi>? jsonOptionsAd,
    ServiceHandler<List<GetBookingDatesResponse>> serviceHandlerGetBookingDatesResponse
    ) : IBookingService
{
    
    public async Task<ResponseModel<BoolResponseDto>> CreateBookingAsync(CreateBookingRequestDto dto)
    {
        var url = serviceHandlerDecimal.CreateConnectionUrlWithQuery(jsonOptionsAd.Value.Url, "api/ad/GetCost/?", $"{dto.AdId}&{dto.Dbeg}&{dto.Dend}" );
        var cost = await serviceHandlerDecimal.GetConnectionHandler(url);
        dto.Cost = cost.Data.Number;
        var jsonContent = JsonConvert.SerializeObject(dto);
        var urllast = serviceHandlerBoolResponseDto.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/deal/create");
        return await serviceHandlerBoolResponseDto.PostConnectionHandler(urllast, jsonContent);
    }

    public async Task<ResponseModel<List<GetBookingDatesResponse>>> GetBookingDatesAsync(RequestById id)
    {
        var url = serviceHandlerGetBookingDatesResponse.CreateConnectionUrlWithQuery(jsonOptions.Value.Url,
            "api/booking/getbookingdates/?", $"{id}");
        return await serviceHandlerGetBookingDatesResponse.GetConnectionHandler(url);;
    }
}