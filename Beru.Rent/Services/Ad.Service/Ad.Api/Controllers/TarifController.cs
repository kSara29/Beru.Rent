using Ad.Dto.CreateDtos;
using Microsoft.AspNetCore.Mvc;

namespace Ad.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarifController : ControllerBase
{
    private readonly ITarifService _tarifService;

    public TarifController(ITarifService tarifService)
    {
        _tarifService = tarifService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateTarifPost([FromBody] CreateTarifDto createTarifDto)
    {
        var result = await _tarifService.CreateTarifAsync(createTarifDto);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTarifPost([FromBody] Guid id)
    {
        var result = await _tarifService.DeleteTarifAsync(id);

        return Ok(result);
    }
}