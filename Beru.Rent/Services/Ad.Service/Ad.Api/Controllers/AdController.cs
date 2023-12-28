using Ad.Api.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Ad.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdController:ControllerBase
{
    private readonly IAdService _service;

    public AdController(IAdService service)
    {
        _service = service;
    }
    
    [HttpPost("/api/ad/create")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAdAsync([FromForm] CreateAdDto dto)
    {
       var result =  await _service.CreateAdAsync(dto);
       return Ok(result);
    }
    
    [HttpGet("/api/ad/create")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAdAsync()
    {
       
        return Ok();
    }
}