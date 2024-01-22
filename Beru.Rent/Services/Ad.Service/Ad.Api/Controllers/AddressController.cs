using Ad.Application.Contracts.Address;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Microsoft.AspNetCore.Mvc;

namespace Ad.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController:ControllerBase
{
    private readonly IAddressService<CreateAddressExtraDto, AddressExtraDto> _addressExtraService;
    private readonly HttpClient _httpClient;
    private readonly string _dadataToken = "6eccf7edd6d4d8526063c7f9ffda8de2b50a5cb6";

    public AddressController(IAddressService<CreateAddressExtraDto, AddressExtraDto> addressExtraService, HttpClient httpClient)
    {
        _addressExtraService = addressExtraService;
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Token {_dadataToken}");
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
    public async Task<string> SuggestAddress(string query)
    {
        var response = await _httpClient.PostAsJsonAsync("https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address", new { query });
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }
    
    
}