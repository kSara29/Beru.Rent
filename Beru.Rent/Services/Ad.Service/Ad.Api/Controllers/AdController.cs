﻿using Ad.Application.Contracts.File;
using Ad.Application.Contracts.Ad;
using Ad.Dto.CreateDtos;
using Deal.Dto.Booking;
using Microsoft.AspNetCore.Mvc;

namespace Ad.Api.Controllers;

[ApiController]

public class AdController:ControllerBase
{
    private readonly IAdService _service;
    private readonly IFileService _fileService;

    public AdController(IAdService service, IFileService fileService)
    {
        _service = service;
        _fileService = fileService;
    }
    
    [HttpPost("/api/ad/create")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAdAsync([FromForm] CreateAdDto dto)
    {
       var result =  await _service.CreateAdAsync(dto);
        foreach (var file in dto.Files)
        {
            var fileDto = new CreateFileDto(result.Data!.Id, file);
            await _fileService.UploadFileAsync(fileDto);
        }
       
        return Ok(result);
    }
    
    [HttpGet("/api/ad/get/{id}")]
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
        [FromQuery] string cat ="all")
    {
        var result = await _service.GetAllAdAsync(page, sortdate, sortprice, cat);
        return Ok(result);
    }
    
    [HttpPost("/api/ad/getCost")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCostAsync(CreateBookingRequestDto dto)
    {
        var result = await _service.GetCostAsync(dto);
        return Ok(result);
    }
    
    [HttpGet("api/ad/getAdsByUserId/{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAdsByUserId([FromRoute] Guid id)
    {
        var result = await _service.GetAdsByUserId(id);
        return Ok(result);
    }
    

}