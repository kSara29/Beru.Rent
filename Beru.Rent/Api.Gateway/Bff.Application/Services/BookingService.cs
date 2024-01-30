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
    ServiceHandler<BoolResponseDto> serviceHandleBoolResponseDto,
    IOptions<RequestToDealApi> jsonOptions,
    IOptions<RequestToAdApi> jsonOptionsAd
    ) : IBookingService
{
    
    public async Task<ResponseModel<BoolResponseDto>> CreateBookingAsync(CreateBookingRequestDto dto)
    {
        var url = serviceHandlerDecimal.CreateConnectionUrlWithQuery(jsonOptionsAd.Value.Url, "api/ad/GetCost/?", $"{dto.AdId}&{dto.Dbeg}&{dto.Dend}" );
        var cost = await serviceHandlerDecimal.GetConnectionHandler(url);
        dto.Cost = cost.Data.Number;
        var jsonContent = JsonConvert.SerializeObject(dto);
        var urllast = serviceHandleBoolResponseDto.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/deal/create");
        return await serviceHandleBoolResponseDto.PostConnectionHandler(urllast, jsonContent);
    }
}