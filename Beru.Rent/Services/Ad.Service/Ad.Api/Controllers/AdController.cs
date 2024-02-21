using Ad.Application.Contracts.File;
using Ad.Application.Contracts.Ad;
using Ad.Application.Contracts.Address;
using Ad.Application.DTO.GetDtos;
using Ad.Domain.Models;
using Ad.Dto.CreateDtos;
using Ad.Dto.RequestDto;
using Deal.Dto.Booking;
using Microsoft.AspNetCore.Mvc;

namespace Ad.Api.Controllers;

[ApiController]

public class AdController:ControllerBase
{
    private readonly IAdService _service;
    private readonly IAddressService<CreateAddressExtraDto, AddressExtraDto> _addressExtraService;
    private readonly IFileService _fileService;

    public AdController(IAdService service, IFileService fileService, IAddressService<CreateAddressExtraDto, AddressExtraDto> addressExtraService)
    {
        _service = service;
        _fileService = fileService;
        _addressExtraService = addressExtraService;
    }
    
    [HttpPost("/api/ad/create")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAdAsync([FromForm]CreateAdDto ad)
    {
        
        var newAddressDto = new CreateAddressExtraDto
        {
            House = ad.House,
            Street = ad.Street,
            Country = ad.Country,
            City = ad.City,
            Region = ad.Region,
            Apartment = ad.Apartment,
            Longitude = ad.Longitude,
            Latitude = ad.Latitude,
            PostIndex = ad.PostIndex,
            Floor = ad.Floor
        };
       var guidResp =  await _addressExtraService.CreateAsync(newAddressDto);
       ad.AddressExtraId = guidResp.Data?.Id;
       var result =  await _service.CreateAdAsync(ad);
       foreach (var file in ad.Files)
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
    
    [HttpGet("/api/ad/findget/")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFindAdAsync(
        [FromQuery] int page = 0,
        [FromQuery] string sortdate = "",
        [FromQuery] string sortprice = "",
        [FromQuery] string cat ="all",
        [FromQuery] string finder ="all")
    {
        var result = await _service.GetAllFindAdAsync(page, sortdate, sortprice, cat, finder);
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
        return Ok(result);}
    

}