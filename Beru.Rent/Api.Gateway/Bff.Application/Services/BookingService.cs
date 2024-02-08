using Ad.Dto.GetDtos;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Deal.Dto.Booking;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Application.Services;

public class BookingService(
    ServiceHandler serviceHandler,
    IOptions<RequestToDealApi> jsonOptions,
    IOptions<RequestToAdApi>? jsonOptionsAd,
    IUserService userService) : IBookingService
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

    public async Task<ResponseModel<GetDealPagesDto<GetBookingResponseDto>>> GetAllBookingsAsync(GetDealPagesRequestDto dto)
    {
        var url =
            serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, 
                "api/booking/getallbookings/?",$"id={dto.Id}&page={dto.Page}");
        var result = await serviceHandler.GetConnectionHandler<GetDealPagesDto<GetBookingResponseDto>>(url);

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

    public async Task<ResponseModel<GetDealPagesDto<GetBookingResponseDto>>> GetAllTenantBookingsAsync(GetDealPagesRequestDto dto)
    {
        var lastUrl =
            serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, 
                "api/booking/getalltenantbookings/?",$"id={dto.Id}&page={dto.Page}");

        var result = await serviceHandler.GetConnectionHandler<GetDealPagesDto<GetBookingResponseDto>>(lastUrl);
        
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