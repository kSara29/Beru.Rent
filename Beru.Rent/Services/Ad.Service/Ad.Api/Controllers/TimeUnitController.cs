using Ad.Application.Contracts.TimeUnit;
using Ad.Application.DTO.CreateDtos;
using Microsoft.AspNetCore.Mvc;

namespace Ad.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeUnitController:ControllerBase
{
    private readonly ITimeUnitService _service;

    public TimeUnitController(ITimeUnitService service)
    {
        _service = service;
    }
    
    [HttpPost("/api/timeunit/post/create")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync(CreateTimeUnitDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }
    
    [HttpGet("/api/timeunit/get/{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var result = await _service.GetAsync(id);
        return Ok(result);
    }
    
    [HttpGet("/api/timeunit/get/")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
}