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

    public AddressController(IAddressService<CreateAddressExtraDto, AddressExtraDto> addressExtraService)
    {
        _addressExtraService = addressExtraService;
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
}