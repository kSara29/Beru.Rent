using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Bff.Application.Contracts;

public interface ITagService
{
    Task<ResponseModel<GuidResponse>> CreateTagAsync(TagDto tag);
  
}