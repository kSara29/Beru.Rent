using Ad.Api.DTO.Tarif;
using Ad.Api.Mapper;
using Ad.Application.Lib.Contracts.Tarif;
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
        await _tarifService.CreateTarifAsync(createTarifDto.ToDomain());
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTarifPost([FromBody] Guid id)
    {
        var result = await _tarifService.DeleteTarifAsync(id);

        return result ? Ok() : BadRequest();
    }
}