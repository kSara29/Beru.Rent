using Ad.Application.Contracts.Address;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Mapper;
using Ad.Application.Responses;
using Ad.Domain.Models;

namespace Ad.Application.Services;
#region работа с Extra Address


public class AddressExtraService:IAddressService<CreateAddressExtraDto,AddressExtraDto>
{
    private readonly IAddressRepository<AddressExtra> _repository;

    public AddressExtraService(IAddressRepository<AddressExtra> repository)
    {
        _repository = repository;
    }

    public async Task<BaseApiResponse<Guid>> CreateAsync(CreateAddressExtraDto dto)
    {
       var result = await _repository.CreateAsync(dto.ToDomain());
       return new BaseApiResponse<Guid>(result);
    }


    public async  Task<BaseApiResponse<string>> RemoveAsync(Guid id )
    {
        var result = await _repository.RemoveAsync(id);
        return new BaseApiResponse<string>(result);
    }

    public async  Task<BaseApiResponse<AddressExtraDto?>> GetAsync(Guid id)
    {
        var result = await _repository.GetAsync(id);
        return new BaseApiResponse<AddressExtraDto?>(result.ToDto());
    }
}
#endregion

