using Bff.Application.Contracts;
using Bff.Application.JsonOptions;
using Bff.Application.Maping;
using Common;
using Deal.Dto.Booking;
using Microsoft.Extensions.Options;

namespace Bff.Application.Services;

public class DealServiceGet
(ServiceMaping<GetAllBookingDto> serviceMaping, 
    IOptions<RequestToDealApi> jsonOptions) : IDealServiceGet
{
    public async Task<ResponseModel<GetAllBookingDto>> GetAllBookingAsync()
    {
        var httpConnection =
            await serviceMaping.HttpGetConnection(jsonOptions.Value.GetAllBookings);
        
        var responce = 
            await serviceMaping.ResponceModelMaping(httpConnection);
        return responce;
    }
}