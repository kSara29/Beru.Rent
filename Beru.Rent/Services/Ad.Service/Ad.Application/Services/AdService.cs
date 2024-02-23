using Ad.Application.Contracts.Ad;
using Ad.Application.Contracts.File;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Mapper;
using Ad.Application.Contracts.Ad;
using Ad.Application.Responses;
using Ad.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Ad.Dto;
using Ad.Dto.GetDtos;
using Ad.Dto.RequestDto;
using Ad.Dto.ResponseDto;
using Common;
using Deal.Dto.Booking;
using Microsoft.AspNetCore.Http;
using CreateAdDto = Ad.Dto.CreateDtos.CreateAdDto;

namespace Ad.Application.Services;

public class AdService : IAdService
{
    private readonly IAdRepository _repository;
    private readonly IFileRepository _fileRepository;

    public AdService(IAdRepository repository,IFileRepository fileRepository)
    {
        _repository = repository;
        _fileRepository = fileRepository;
    }
    public async Task<ResponseModel<GuidResponse>> CreateAdAsync(CreateAdDto ad)
    {
       var result =await _repository.CreateAdAsync(ad.ToDomain());
       return ResponseModel<GuidResponse>.CreateSuccess(new GuidResponse
       {
           Id = result
       });
    }

    public async Task<ResponseModel<AdDto>> GetAdAsync(Guid id)
    {
        var result = await _repository.GetAdAsync(id);
        if (result != null)
        {
              var data = result.ToDto();
              var files = await _fileRepository.GetAllFilesAsync(id);
              data.Files = files;
              var response = ResponseModel<AdDto>.CreateSuccess(data);
              return response;
        }
        else
        {
          var errors = new List<ResponseError>();
                  var errorModel = new ResponseError
                  {
                      Code = "404",
                      Message = "С таким Id объявления не найдено"
                  };
                  errors.Add(errorModel);
                  return ResponseModel<AdDto>.CreateFailed(errors);  
        }
    }

    public async Task<ResponseModel<List<AdDto>>> GetAdsByUserId(Guid userId)
    {
        var result = await _repository.GetAdsByUserId(userId);
        if (result != null)
        {
            var data = result.Select(a=>a.ToDto()).ToList();
            foreach (var ad in data)
            {
                var files = await _fileRepository.GetAllFilesAsync(ad.Id);
                ad.Files = files;
            }
            
            var response = ResponseModel<List<AdDto>>.CreateSuccess(data);
            return response;
        }
        else
        {
            var errors = new List<ResponseError>();
            var errorModel = new ResponseError
            {
                Code = "404",
                Message = "Ни одного объявления не найдено"
            };
            errors.Add(errorModel);
            return ResponseModel<List<AdDto>>.CreateFailed(errors);  
        }
    }

    public async Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllAdAsync(
        int page, string sortdate, string sortprice, string cat)
    {
        var result = await _repository.GetAllAdAsync(page,sortdate,sortprice,cat);
        var mainPageDto = new GetMainPageDto<AdMainPageDto>(result.MainPageDto.Select(ad => 
            ad.ToMainPageDto()).ToList(), result.TotalPage);
        
        foreach (var dto in mainPageDto.MainPageDto)
        {
            var files = await _fileRepository.GetAllFilesAsync(dto.Id);
            dto.Files = files;
        }

        return ResponseModel<GetMainPageDto<AdMainPageDto>>.CreateSuccess(mainPageDto);
    }

    public async Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllFindAdAsync(int page, string sortdate,
        string sortprice, string cat, string finder)
    {
        {
            var result = await _repository.GetAllFindAdAsync(page, sortdate, sortprice, cat, finder);
            var mainPageDto = new GetMainPageDto<AdMainPageDto>(result.MainPageDto.Select(ad =>
                ad.ToMainPageDto()).ToList(), result.TotalPage);

            foreach (var dto in mainPageDto.MainPageDto)
            {
                var files = await _fileRepository.GetAllFilesAsync(dto.Id);
                dto.Files = files;
            }

            return ResponseModel<GetMainPageDto<AdMainPageDto>>.CreateSuccess(mainPageDto);
        }
    }

    public async Task<ResponseModel<DecimalResponse>> GetCostAsync(GetAdCostRequestDto dto)
    {
        var result =await _repository.GetCostAsync(dto);
        return ResponseModel<DecimalResponse>.CreateSuccess(new DecimalResponse
        {
            Number = result
        });
    }

   
}