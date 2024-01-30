using Ad.Application.Contracts.Address;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Mapper;
using Ad.Application.Responses;
using Ad.Domain.Models;
using Ad.Dto.ResponseDto;
using Common;

namespace Ad.Application.Services;
#region работа с Extra Address


public class AddressExtraService:IAddressService<CreateAddressExtraDto,AddressExtraDto>
{
    private readonly IAddressRepository<AddressExtra> _repository;

    public AddressExtraService(IAddressRepository<AddressExtra> repository)
    {
        _repository = repository;
    }

    public async Task<ResponseModel<GuidResponse>> CreateAsync(CreateAddressExtraDto dto)
    {
       var result = await _repository.CreateAsync(dto.ToDomain());
       return ResponseModel<GuidResponse>.CreateSuccess(new GuidResponse{Id = result});
    }


    public async  Task<ResponseModel<StringResponse>> RemoveAsync(Guid id )
    {
        var result = await _repository.RemoveAsync(id);
        return ResponseModel<StringResponse>.CreateSuccess(new StringResponse{Text = result});
    }

    public async  Task<ResponseModel<AddressExtraDto?>> GetAsync(Guid id)
    {
        var result = await _repository.GetAsync(id);
        if (result != null)
        {
          return ResponseModel<AddressExtraDto?>.CreateSuccess(result.ToDto());  
        }
        var errors = new List<ResponseError>();
        var errorModel = new ResponseError
        {
            Code = "404",
            Message = "С таким Id адреса не найдено"
        };
        errors.Add(errorModel);
        return ResponseModel<AddressExtraDto?>.CreateFailed(errors);  
        
    }
}
#endregion

