using Ad.Application.Contracts.Category;
using Ad.Application.DTO.CreateDtos;
using Microsoft.AspNetCore.Mvc;

namespace Ad.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController:ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }
    
    [HttpPost("/api/category/post/")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromBody] CreateCategoryDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }
    
    [HttpGet("/api/category/get/{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var result = await _service.GetAsync(id);
        return Ok(result);
    }
    
    [HttpGet("/api/category/get/")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
}