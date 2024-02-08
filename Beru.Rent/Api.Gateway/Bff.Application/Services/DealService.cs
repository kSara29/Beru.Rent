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
    IUserService userService
    ) : IDealService
{
    public async Task<ResponseModel<CreateDealResponseDto>> CreateDealAsync(CreateDealRequestDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/deal/create");
        return await serviceHandler.PostConnectionHandler<CreateDealRequestDto, CreateDealResponseDto>(url, dto);
    }

    public async Task<ResponseModel<GetDealResponseDto>> GetDealAsync(GetDealRequestDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/booking/GetDeal/",
            $"{dto.DealId}");
        return await serviceHandler.GetConnectionHandler<GetDealResponseDto>(url);
    }

    public async Task<ResponseModel<GetDealPagesDto<GetDealResponseDto>>> GetAllDealsAsync(GetDealPagesRequestDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/booking/GetAllDeals/?",
            $"id={dto.Id}&page={dto.Page}");

        var result = await serviceHandler.GetConnectionHandler<GetDealPagesDto<GetDealResponseDto>>(url);
        foreach (var variable in result.Data.DealPageDto)
        {
            var resultOwnerName = await userService.GetUserByIdAsync(variable.OwnerId);
            if (resultOwnerName is not null)
                variable.OwnerName = resultOwnerName.Data.UserName;
            
            var resultTenantName = await userService.GetUserByIdAsync(variable.TenantId);
            if (resultTenantName is not null) 
                variable.TenantName = resultTenantName.Data.UserName;
        }
        
        return result;
    }

    public async Task<ResponseModel<GetDealPagesDto<GetDealResponseDto>>> GetAllTenantDealsAsync(GetDealPagesRequestDto dto)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/booking/GetAllTenantDeals/?",
            $"id={dto.Id}&page={dto.Page}");
        var result = await serviceHandler.GetConnectionHandler<GetDealPagesDto<GetDealResponseDto>>(url);
        foreach (var variable in result.Data.DealPageDto)
        {
            var resultOwnerName = await userService.GetUserByIdAsync(variable.OwnerId);
            if (resultOwnerName is not null)
                variable.OwnerName = resultOwnerName.Data.UserName;
            
            var resultTenantName = await userService.GetUserByIdAsync(variable.TenantId);
            if (resultTenantName is not null) 
                variable.TenantName = resultTenantName.Data.UserName;
        }
        
        return result;
    }
}