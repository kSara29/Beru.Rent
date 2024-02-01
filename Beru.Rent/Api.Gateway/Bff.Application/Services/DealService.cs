using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Deal.Dto.Booking;
using Microsoft.Extensions.Options;

namespace Bff.Application.Services;

public class DealService(
    ServiceHandler serviceHandler,
    IOptions<RequestToDealApi> jsonOptions,
    IOptions<RequestToAdApi>? jsonOptionsAd
    ) : IDealService
{
    public async Task<ResponseModel<CreateDealResponseDto>> CreateDealAsync(CreateDealRequestDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/deal/create");
        return await serviceHandler.PostConnectionHandler<CreateDealRequestDto, CreateDealResponseDto>(url, dto);
    }

    public async Task<ResponseModel<GetDealResponseDto>> GetDealAsync(GetDealRequestDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/booking/GetDeal/?",
            $"{dto.dealId}");
        return await serviceHandler.GetConnectionHandler<GetDealResponseDto>(url);
    }

    public async Task<ResponseModel<List<GetAllDealsResponseDto>>> GetAllDealsAsync(RequestByUserId dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/booking/GetAllDeals/?",
            $"{dto.Id}");
        return await serviceHandler.GetConnectionHandler<List<GetAllDealsResponseDto>>(url);
    }
}