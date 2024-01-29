using System.Text.Json;
using Bff.Application.Contracts;
using Bff.Application.JsonOptions;
using Bff.Application.Maping;
using Common;
using Deal.Dto.Booking;
using Microsoft.Extensions.Options;

namespace Bff.Application.Services;

public class DealServiceCreate
    (ServiceMaping<BookingDto> serviceMapping,
        IOptions<RequestToDealApi> jsonOptions) : IDealServiceCreate
{
    public async Task<ResponseModel<BookingDto>> CreateBookingAsync(CreateBookingRequestDto request)
    {
        var content = JsonSerializer.Serialize(request);
        var httpConnection =
            await serviceMapping.HttpPostConnection(jsonOptions.Value.CreateBooking, content);
        
        var responce = 
            await serviceMapping.ResponceModelMaping(httpConnection);
        return responce;
    }
}