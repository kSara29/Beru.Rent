using Ad.Application.DTO.GetDtos;
using Ad.Dto.CreateDtos;
using Ad.Dto.GetDtos;
using Ad.Dto.RequestDto;
using Ad.Dto.ResponseDto;
using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.JsonOptions;
using Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using User.Dto;

namespace Bff.Application.Services;

public class AdService(
    ServiceHandler serviceHandler,
    IAddressService addressService,
    IOptions<RequestToAdApi> jsonOptions)
    :IAdService

{
    public async Task<ResponseModel<GuidResponse>> CreateAdAsync(CreateAdDto ad)
    {
        //сначала создаю сущность адреса и отправляю на сохранение, в ответ получаю айди
        var newAddressDto = new CreateAddressExtraDto
        {
            House = ad.House,
            Street = ad.Street,
            Country = ad.Country,
            City = ad.City,
            Region = ad.Region,
            Apartment = ad.Apartment,
            Longitude = ad.Longitude,
            Latitude = ad.Latitude,
            PostIndex = ad.PostIndex,
            Floor = ad.Floor
        };
        var responseAddress = await addressService.CreateAddressAsync(newAddressDto);
        // Обогощаю ДТО объявления айди адреса и отправляю на сохранение
        ad.AddressExtraId = responseAddress.Data?.Id;
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/ad/create");

        return await serviceHandler.PostConnectionHandler<CreateAdDto, GuidResponse>(url, ad);
    }


    public async Task<ResponseModel<AdDto>> GetAdAsync(RequestById id)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/ad/get/", id.Id.ToString());
        var result = await serviceHandler.GetConnectionHandler<AdDto>(url);
        return result;
    }
    
    public async Task<ResponseModel<List<AdDto>>> GetAdsByUserIdAsync(RequestById userId)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
            (jsonOptions.Value.Url, "api/ad/getAdsByUserId/", userId.Id.ToString());
        var result = await serviceHandler.GetConnectionHandler<List<AdDto>>(url);
        return result;
    }
            

    public async Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllAdAsync(MainPageRequestDto requestDto)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
        (jsonOptions.Value.Url, "api/ad/get/?", 
            $"page={requestDto.Page}&sortdate={requestDto.SortDate}" +
            $"&sortprice={requestDto.SortPrice}&cat={requestDto.CategoryName}");
        var result = 
            await serviceHandler.GetConnectionHandler<GetMainPageDto<AdMainPageDto>>(url);
        return result;
    }

    public async Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllFindAdAsync(FindMainPageRequestDto requestDto)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery
        (jsonOptions.Value.Url, "api/ad/findget/?", 
            $"page={requestDto.Page}&sortdate={requestDto.SortDate}" +
            $"&sortprice={requestDto.SortPrice}&cat={requestDto.CategoryName}" +
            $"&finder={requestDto.Finder}");
        var result = 
            await serviceHandler.GetConnectionHandler<GetMainPageDto<AdMainPageDto>>(url);
        return result;
    }

    public Task<ResponseModel<DecimalResponse>> GetCostAsync(RequestById adId, DateTime ebeg, DateTime dend)
    {
        throw new NotImplementedException();
    }

  
}