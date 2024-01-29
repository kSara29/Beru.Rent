using Ad.Api.Request;
using Ad.Application.Contracts.Address;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ad.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController:ControllerBase
{
    private readonly IAddressService<CreateAddressExtraDto, AddressExtraDto> _addressExtraService;
    private readonly HttpClient _httpClient;
    private readonly string _yandexToken = "3305a045-226e-4b6c-ab37-49746a18655d";
    
    public AddressController(IAddressService<CreateAddressExtraDto, AddressExtraDto> addressExtraService, HttpClient httpClient)
    {
        _addressExtraService = addressExtraService;
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Token {_yandexToken}");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }
    

    [HttpPost("/api/address/extra/create")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromForm] CreateAddressExtraDto dto)
    {
        var result =  await _addressExtraService.CreateAsync(dto);
        return Ok(result);
    }

    
    [HttpGet("/api/address/extra/get/{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExtraAsync([FromRoute] Guid id)
    {
        var result = await _addressExtraService.GetAsync(id);
        return Ok(result);
    }
    
    
    [HttpDelete("/api/address/extra/delete/{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> RemoveExtraAsync([FromRoute] Guid id)
    {
        var result = await _addressExtraService.RemoveAsync(id);
        return Ok(result);
    }
    
    
    [HttpPost("/api/address/suggestions")]
    public async Task<List<string>> SuggestAddress([FromBody] QueryModel model)
    {
        string url = $"https://suggest-maps.yandex.ru/v1/suggest?apikey={_yandexToken}&text={model.Query}&print_address=1&results=20";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(responseBody);
                var results = jsonDoc.RootElement.GetProperty("results");
                var addresses = results.EnumerateArray()
                    .Select(result => result.GetProperty("address").GetProperty("formatted_address").GetString())
                    .ToList();
                return addresses;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Ошибка :{0} ", e.Message);
            }
        }

        return new List<string>();
    }
}