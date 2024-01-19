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
    
    [HttpGet("/api/ad/get/{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAdAsync([FromRoute] Guid id)
    {
        var result = await _service.GetAdAsync(id);
        return Ok(result);
    }
    [HttpGet("/api/ad/get/")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAdAsync(
        [FromQuery] int page = 0,
        [FromQuery] string sortdate = "",
        [FromQuery] string sortprice = "",
        [FromQuery] Guid cat =default)
    {
        var result = await _service.GetAllAdAsync(page, sortdate, sortprice, cat);
        return Ok(new {result.Data.MainPageDto, result.Data.TotalPage});
    }
}