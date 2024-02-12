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
    HttpClient httpClient,
    IAddressService addressService,
    IOptions<RequestToAdApi> jsonOptions)
    :IAdService

{
    public async Task<ResponseModel<GuidResponse>> CreateAdAsync(CreateAdDto ad)
    {
        try
        {
            var apiUrl = "http://localhost:5105/api/ad/create"; // Change the URL accordingly

            var formContent = new MultipartFormDataContent();
            
            foreach (var property in typeof(CreateAdDto).GetProperties())
            {
                var value = property.GetValue(ad);
                if (value != null)
                {
                    formContent.Add(new StringContent(value.ToString()), property.Name);
                }
                
            }

            // Add files to the form content
            foreach (var file in ad.Files)
            {
                var fileContent = new StreamContent(file.OpenReadStream());
                formContent.Add(fileContent, "files", file.FileName);
            }

            var response = await httpClient.PostAsync(apiUrl, formContent);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                throw new Exception($"Failed to send ad. StatusCode: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            // Log or handle exception accordingly
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
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